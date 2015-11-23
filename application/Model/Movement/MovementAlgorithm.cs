using BioBotApp.Model.Data;
using BioBotCommunication.Serial.Can;
using BioBotCommunication.Serial.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Model.Movement
{
    class MovementAlgorithm
    {
        DBManager dbManager;        
        ArduinoCommunicationWorker arduinoWorker;        
        CANCommunicationWorker canWorker;

        ToolRack toolRack;
        ToolToMove toolToMove;        
        Movement movementToDo;

        List<string> commandsToSendList = new List<string>();

        private static MovementAlgorithm instance;

        private MovementAlgorithm()
        {
            this.dbManager = DBManager.Instance;            

            // Load the tool rack informations :
            toolRack = new ToolRack(this.dbManager);

            toolToMove = new ToolToMove();
            movementToDo = new Movement();

            arduinoWorker = ArduinoCommunicationWorker.Instance;
            arduinoWorker.onArduinoReceive += Worker_onArduinoReceive;

            canWorker = CANCommunicationWorker.Instance;
            canWorker.OnMessageReceived += CanWorker_OnMessageReceived;            
                                        
        }
        private void CanWorker_OnMessageReceived(object sender, Utils.Communication.pcan.PCANComEventArgs e)
        {
            
            throw new NotImplementedException();
        }

        public static MovementAlgorithm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MovementAlgorithm();
                }
                return instance;
            }
        }

        public void LoadTipOnPipette(BioBotDataSets.bbt_operationRow operationRow)
        {
            if (operationRow.bbt_operation_typeRow.description == "Load Tip")
            {
                BioBotDataSets.bbt_stepRow stepToRun = operationRow.bbt_stepRow;
                BioBotDataSets.bbt_objectRow sourceToolRow = stepToRun.bbt_objectRow;

                // Update the tool rack position before starting the movement.
                toolRack.setToolRackPositions(dbManager);                

                // Update the tool to be moved (include update of the attached object if there is one)
                toolToMove.setToolToMove(sourceToolRow, dbManager);

                // Update the information on the tip and box to load
                Box box = new Box();
                Tip tip = new Tip();

                loadBoxAndTipInfos(operationRow, box, tip);

                // Setting the starting point for the movement to be done.
                movementToDo.setStartingPoint(toolRack, toolToMove);

                // Setting the destination point.
                movementToDo.setTipDestinationPoint(box, tip, toolToMove);

                // TODO : Calculate the movements to be done for each axis.
                commandsToSendList.Add("X" + (movementToDo.desiredXPos - movementToDo.initialXPos).ToString());
                commandsToSendList.Add("Y" + (movementToDo.desiredYPos - movementToDo.initialYPos).ToString());

                // TODO : HOME THE Z AXIS OF THE CONCERNED TOOL BEFORE STARTING

                // TODO : Send the command to move the Y and X axis 
                arduinoWorker.startWorker();
                arduinoWorker.write(commandsToSendList.First());
                commandsToSendList.RemoveAt(0);                

                // TODO : LOAD THE TIP ON THE TOOL BY DROPPING Z TO THE CALCULATED VALUE IN movementToDo.


            }
        }

        public int MoveTo(BioBotDataSets.bbt_operationRow operationRow)
        {
            // We verify that the operation_type is really "move"
            if (operationRow.bbt_operation_typeRow.description == "Move")
            {
                try
                {
                    BioBotDataSets.bbt_stepRow stepToRun = operationRow.bbt_stepRow;
                    BioBotDataSets.bbt_objectRow sourceToolRow = stepToRun.bbt_objectRow;

                    // Update the tool rack position before starting the movement.
                    toolRack.setToolRackPositions(dbManager);

                    // Update the tool to be moved (include update of the attached object if there is one)
                    toolToMove.setToolToMove(sourceToolRow, dbManager);

                    // Setting the starting point for the movement to be done.
                    movementToDo.setStartingPoint(toolRack, toolToMove);

                    // Obtaining the desired final position :
                    BioBotDataSets.bbt_objectRow destinationObject = operationRow.Getbbt_operation_referenceRows().First().bbt_objectRow;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message); // REMOVE THE THROW LATER ON
                    return -1;
                }
            }
            else
            {
                return -1;
            }
            return 1;
        }

        public void loadBoxAndTipInfos(BioBotDataSets.bbt_operationRow operationRow, Box b, Tip t)
        {
            IEnumerable<BioBotDataSets.bbt_operation_referenceRow> boxAndTipRows = operationRow.Getbbt_operation_referenceRows();

            foreach (BioBotDataSets.bbt_operation_referenceRow row in boxAndTipRows)
            {
                string objectType = row.bbt_objectRow.bbt_object_typeRow.description.ToString();

                switch (objectType)
                {
                    case "P1000":
                    case "P200":
                    case "P100":
                        t.updateTipProperties(row.bbt_objectRow);
                        break;

                    case "BoxP1000":
                    case "BoxP200":
                    case "BoxP100":
                        b.updateBoxProperties(row);
                        break;

                    default:
                        break;
                }
            }
        }        

        private void Worker_onArduinoReceive(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            arduinoWorker.startWorker();
            arduinoWorker.write(commandsToSendList.First());
            commandsToSendList.RemoveAt(0);
            //throw new NotImplementedException();
        }

        /*
        Étapes :
        1- Trouver la position actuelle du portoir à outils
        2- Trouver la position actuelle de l'objet à déplacer selon les offsets de l'outil par rapport au portoir
        3- Trouver la position en x et y de la destination exacte (ligne entière, puit particulier, etc) selon les offsets déterminés dans la DB pour les plaques, etcs
        4- Home tous les axes en Z au cas où il y aurait des objets dans le chemin de la trajectoire et attendre tous les acknowledge
        5- Calculer le déplacement en X et en Y à envoyer au firmware                
        6- Envoyer le déplacement à faire et attendre le acknowledge
        7- Update la position du portoir selon le déplacement qui a été effectué
        8- Envoyer le déplacement requis pour atteindre la hauteur désirée avec l'outil désiré (ex. envoyer la pipette simple au fond du puit A1 de la plaque de 96 puits visée)
        */
    }

    class ToolRack
    {
        public int xPos { get; set; }
        public int yPos { get; set; }
        public int zPos { get; set; }
        public bool isInitialized { get; set; }       

        public ToolRack(DBManager dbManager)
        {
            isInitialized = false;

            setToolRackPositions(dbManager);            
        }

        public void setToolRackPositions(DBManager dbManager)
        {
            int tempValue;
            int.TryParse(dbManager.projectDataset.bbt_information_value.Where(p => p.bbt_propertyRow.description == "X" && p.bbt_propertyRow.bbt_property_typeRow.description == "ToolRackPosition").First().information_value, out tempValue);
            xPos = tempValue;

            int.TryParse(dbManager.projectDataset.bbt_information_value.Where(p => p.bbt_propertyRow.description == "Y" && p.bbt_propertyRow.bbt_property_typeRow.description == "ToolRackPosition").First().information_value, out tempValue);
            yPos = tempValue;

            int.TryParse(dbManager.projectDataset.bbt_information_value.Where(p => p.bbt_propertyRow.description == "Z" && p.bbt_propertyRow.bbt_property_typeRow.description == "ToolRackPosition").First().information_value, out tempValue);
            zPos = tempValue;
        }

        public void updateToolRackPositions(int newXPos, int newYPos, int newZPos)
        {
            // Must apply the new positions in the database.

        }
    }    

    class ToolToMove
    {
        public Object attachedObject { get; set; }
        public ToolType toolType { get; set; }

        public bool hasAttachedObject { get; set; }
        public bool isSet { get; set; }

        public int xToolRackOffset { get; set; }
        public int yToolRackOffset { get; set; }
        public int zToolRackOffset { get; set; }

        public int xLength { get; set; }
        public int yLength { get; set; }
        public int zLength { get; set; }
        public int radius { get; set; }       

        public ToolToMove()
        {
            isSet = false;
            toolType = new ToolType();
            attachedObject = new Object();
        }

        public void setToolToMove(BioBotDataSets.bbt_objectRow sourceToolRow, DBManager dbManager)
        {
            // Setting the Tool Type :
            if (sourceToolRow.bbt_object_typeRow.description == "Single Channel Pipette")
            {
                toolType = ToolType.SingleChannelPipette;
            }
            else if (sourceToolRow.bbt_object_typeRow.description == "Multiple Channel Pipette")
            {
                toolType = ToolType.MultipleChannelPipette;
            }
            else if (sourceToolRow.bbt_object_typeRow.description == "Gripper")
            {
                toolType = ToolType.Gripper;
            }

            // Loading the dimensions of the tool :
            loadDimensions(sourceToolRow);

            // Get all objects attached to the source Tool (There should be only one):
            IEnumerable<BioBotDataSets.bbt_objectRow> attachedObjectsRows = sourceToolRow.Getbbt_objectRows();

            if (attachedObjectsRows.Any())
            {
                attachedObject.updateObject(attachedObjectsRows.First());
            }

            setToolOffsets(sourceToolRow, dbManager);
        }

        private void loadDimensions(BioBotDataSets.bbt_objectRow row)
        {
            // Load the length on the X axis of the object
            if (row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "XLength").Any())
            {
                int tempValue;
                int.TryParse(row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "XLength").First().value, out tempValue);
                xLength = tempValue;
            }

            // Load the length on the Y axis of the object
            if (row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "YLength").Any())
            {
                int tempValue;
                int.TryParse(row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "YLength").First().value, out tempValue);
                yLength = tempValue;
            }

            // Load the length on the Z axis of the object
            if (row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "ZLength").Any())
            {
                int tempValue;
                int.TryParse(row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "ZLength").First().value, out tempValue);
                zLength = tempValue;
            }

            // Load the radius of the object
            if (row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "Radius").Any())
            {
                int tempValue;
                int.TryParse(row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "Radius").First().value, out tempValue);
                radius = tempValue;
            }
        }

        private void setToolOffsets(BioBotDataSets.bbt_objectRow sourceToolRow, DBManager dbManager)
        {     
            IEnumerable<BioBotDataSets.bbt_property_typeRow> toolRackOffsetPropertyTypeRows = dbManager.projectDataset.bbt_property_type.Where(p => p.description == "ToolRackOffset");
            
            if (toolRackOffsetPropertyTypeRows.Any())
            {
                BioBotDataSets.bbt_property_typeRow toolRackOffsetPropertyTypeRow = toolRackOffsetPropertyTypeRows.First();

                IEnumerable<BioBotDataSets.bbt_propertyRow> toolRackOffsets = toolRackOffsetPropertyTypeRow.Getbbt_propertyRows();

                if (toolRackOffsets.Any())
                {
                    int tempValue;

                    int.TryParse(dbManager.projectDataset.bbt_information_value.Where(p => p.fk_object == sourceToolRow.pk_id && p.fk_property == toolRackOffsets.Where(q => q.description == "X").First().pk_id).First().information_value, out tempValue);
                    xToolRackOffset = tempValue;

                    int.TryParse(dbManager.projectDataset.bbt_information_value.Where(p => p.fk_object == sourceToolRow.pk_id && p.fk_property == toolRackOffsets.Where(q => q.description == "Y").First().pk_id).First().information_value, out tempValue);
                    yToolRackOffset = tempValue;

                    int.TryParse(dbManager.projectDataset.bbt_information_value.Where(p => p.fk_object == sourceToolRow.pk_id && p.fk_property == toolRackOffsets.Where(q => q.description == "Z").First().pk_id).First().information_value, out tempValue);
                    zToolRackOffset = tempValue;

                    isSet = true;
                }
            }
            else
            {
                isSet = false;
            }
        }
    }    

    class Object
    {
        public int xDeckPos { get; set; }
        public int yDeckPos { get; set; }
        public int xLength { get; set; }
        public int yLength { get; set; }
        public int zLength { get; set; }
        public int radius { get; set; }
        public int zOffset { get; set; }

        public bool isRectangular { get; set; }
        public bool isCircular { get; set; }        

        public bool isGrippable { get; set; }
        public bool isAttachableToPipette { get; set; }

        public bool isSet { get; set; }

        public Object()
        {
            isSet = false;            
        }

        public void updateObject(BioBotDataSets.bbt_objectRow row)
        {            
            xDeckPos = row.deck_x;
            yDeckPos = row.deck_y;

            // Verify if the object can be attached a pipette :
            if (row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "AttachableToPipette").Any())
            {
                isAttachableToPipette = true;
            }
            else
            {
                isAttachableToPipette = false;
            }

            // Verify if the object is grippable :
            if (row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "Grippable").Any())
            {
                isGrippable = true;
            }
            else
            {
                isGrippable = false;
            }

            // Load the offset that the object adds on the Z axis.
            if (row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "AddedZOffset").Any())
            {
                int tempValue;
                int.TryParse(row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "AddedZOffset").First().value, out tempValue);
                zOffset = tempValue;
            }

            loadDimensions(row);

            if (radius != 0)
            {
                isRectangular = false;
                isCircular = true;
            }
            else
            {
                isRectangular = true;
                isCircular = false;
            }

            isSet = true;
        }

        private void loadDimensions(BioBotDataSets.bbt_objectRow row)
        {
            // Load the length on the X axis of the object
            if (row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "XLength").Any())
            {
                int tempValue;
                int.TryParse(row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "XLength").First().value, out tempValue);
                xLength = tempValue;
            }

            // Load the length on the Y axis of the object
            if (row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "YLength").Any())
            {
                int tempValue;
                int.TryParse(row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "YLength").First().value, out tempValue);
                yLength = tempValue;
            }

            // Load the length on the Z axis of the object
            if (row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "ZLength").Any())
            {
                int tempValue;
                int.TryParse(row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "ZLength").First().value, out tempValue);
                zLength = tempValue;
            }

            // Load the radius of the object
            if (row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "Radius").Any())
            {
                int tempValue;
                int.TryParse(row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "Radius").First().value, out tempValue);
                radius = tempValue;
            }
        }
    }

    class Tip : Object
    {
        public int zBoxOffset { get; set; }
        public int zPipetteOffset { get; set; }

        public Tip()
        {
            isSet = false;
            zBoxOffset = 0;
            zPipetteOffset = 0;
        }

        public void updateTipProperties(BioBotDataSets.bbt_objectRow objectRow)
        {
            updateObject(objectRow);

            int tempValue;

            int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "ContainerOffset").First().value, out tempValue);
            zBoxOffset = tempValue;

            int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "PipetteOffset").First().value, out tempValue);
            zPipetteOffset = tempValue;
        }
    }

    class Box : Object
    {
        public int firstWellXBoxOffset { get; set; }
        public int firstWellYBoxOffset { get; set; }
        public int totalWellCount { get; set; }
        public int xWellCount { get; set; }
        public int yWellCount { get; set; }
        public int xWellOffset { get; set; }
        public int yWellOffset { get; set; }
        public int chosenWell { get; set; }
        public int chosenWellRow { get; set; }

        public Box()
        {
            isSet = false;
            firstWellXBoxOffset = 0;
            firstWellYBoxOffset = 0;
            totalWellCount = 0;
            xWellCount = 0;
            yWellCount = 0;
            xWellOffset = 0;
            yWellOffset = 0;
            chosenWell = 0;
            chosenWellRow = 0;
        }

        public void updateBoxProperties(BioBotDataSets.bbt_operation_referenceRow operation_referenceRow)
        {
            BioBotDataSets.bbt_objectRow objectRow = operation_referenceRow.bbt_objectRow;
            bool getGoing = true;
            isSet = false;

            while (getGoing == true  && isSet == false)
            {
                updateObject(objectRow);

                int tempValue;

                getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "XOffset" && p.bbt_propertyRow.bbt_property_typeRow.description == "FirstWell").First().value, out tempValue);
                firstWellXBoxOffset = tempValue;

                getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "YOffset" && p.bbt_propertyRow.bbt_property_typeRow.description == "FirstWell").First().value, out tempValue);
                firstWellYBoxOffset = tempValue;

                getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "Total" && p.bbt_propertyRow.bbt_property_typeRow.description == "WellCount").First().value, out tempValue);
                totalWellCount = tempValue;

                getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "XCount" && p.bbt_propertyRow.bbt_property_typeRow.description == "WellCount").First().value, out tempValue);
                xWellCount = tempValue;

                getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "YCount" && p.bbt_propertyRow.bbt_property_typeRow.description == "WellCount").First().value, out tempValue);
                yWellCount = tempValue;

                getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "XOffset" && p.bbt_propertyRow.bbt_property_typeRow.description == "WellOffset").First().value, out tempValue);
                xWellOffset = tempValue;
                
                getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "YOffset" && p.bbt_propertyRow.bbt_property_typeRow.description == "WellOffset").First().value, out tempValue);
                yWellOffset = tempValue;

                //getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "ChosenWell" && p.bbt_propertyRow.bbt_property_typeRow.description == "WellProperties").First().value, out tempValue);
                getGoing = int.TryParse(operation_referenceRow.Getbbt_operation_reference_propertyRows().Where(p => p.bbt_propertyRow.description == "ChosenWell" && p.bbt_propertyRow.bbt_property_typeRow.description == "WellProperties").First().value, out tempValue);
                chosenWell = tempValue;

                //getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "ChosenWellRow" && p.bbt_propertyRow.bbt_property_typeRow.description == "WellProperties").First().value, out tempValue);
                getGoing = int.TryParse(operation_referenceRow.Getbbt_operation_reference_propertyRows().Where(p => p.bbt_propertyRow.description == "ChosenWell" && p.bbt_propertyRow.bbt_property_typeRow.description == "WellProperties").First().value, out tempValue);
                chosenWellRow = tempValue;               

                isSet = true;
            }
        }
    }

    enum CommandType { CAN, SERIAL }

    class CommandToSend
    {
        public CommandType cmdType { get; set; }
        public String SerialMsgToSend { get; set; }

    }

    

    class Movement
    {
        public const int ADDED_PENETRATION_DEEPNESS = 30; // Represents 3mm.

        public int initialXPos { get; set; }
        public int initialYPos { get; set; }
        public int initialZPos { get; set; }

        public int desiredXPos { get; set; }
        public int desiredYPos { get; set; }
        public int desiredZPos { get; set; } 
        
        public bool isSet { get; set; }

        public void setStartingPoint(ToolRack _toolRack, ToolToMove _toolToMove)
        {
            initialXPos = _toolRack.xPos + _toolToMove.xToolRackOffset;
            initialYPos = _toolRack.yPos + _toolToMove.yToolRackOffset;
            initialZPos = _toolRack.zPos + _toolToMove.zToolRackOffset + _toolToMove.attachedObject.zOffset;
        }
        
        public void setTipDestinationPoint(Box box, Tip tip, ToolToMove tool)
        {
            int tipAndBoxHeight = box.zLength + tip.zBoxOffset;
            int penetrationDeepness = tip.zLength - tip.zPipetteOffset;

            desiredZPos = tipAndBoxHeight - penetrationDeepness - ADDED_PENETRATION_DEEPNESS;

            int tempX = box.xDeckPos + box.firstWellXBoxOffset;
            int tempY = box.yDeckPos + box.firstWellYBoxOffset;

            if (tool.toolType == ToolType.SingleChannelPipette && box.chosenWell != 0)
            {
                desiredXPos = tempX + (int)Math.Floor((double)(box.chosenWell / box.yWellCount)) * box.xWellOffset;
                desiredYPos = tempY + (box.chosenWell % box.yWellCount) * box.yWellOffset;
            }
            else if (tool.toolType == ToolType.MultipleChannelPipette && box.chosenWellRow != 0)
            {
                desiredXPos = tempX + (int)Math.Floor((double)(box.chosenWell / box.yWellCount)) * box.xWellOffset;
                desiredYPos = tempY;
            }         
        }

        public Movement()
        {
            initialXPos = -1;
            initialYPos = -1;
            initialZPos = -1;

            desiredXPos = -1;
            desiredYPos = -1;
            desiredZPos = -1;

            isSet = false;
        }
    }

    public enum ToolType { Gripper, SingleChannelPipette, MultipleChannelPipette };
}
