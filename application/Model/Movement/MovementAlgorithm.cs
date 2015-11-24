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

        public int Move(BioBotDataSets.bbt_operationRow operationRow)
        {            
            if (operationRow.bbt_operation_typeRow.description == "Move To")
            {
                moveToXYZ(operationRow);
            }
            else if (operationRow.bbt_operation_typeRow.description == "Load Tip")
            {
                GetTips(operationRow);
            }
            else if (operationRow.bbt_operation_typeRow.description == "Unload Tip")
            {
                TrashTips(operationRow);
            }
            else
            {
                return -1;
            }
            return 1;
        }       

        private void Worker_onArduinoReceive(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            arduinoWorker.startWorker();
            arduinoWorker.write(commandsToSendList.First());
            commandsToSendList.RemoveAt(0);
            //throw new NotImplementedException();
        }

        private void GetTips(BioBotDataSets.bbt_operationRow operationRow)
        {
            if (operationRow.bbt_operation_typeRow.description == "Load Tip")
            {
                BioBotDataSets.bbt_stepRow stepToRun = operationRow.bbt_stepRow;
                BioBotDataSets.bbt_objectRow sourceToolRow = stepToRun.bbt_objectRow;

                // Update the tool rack position before starting the movement.
                toolRack.setToolRackPositions(dbManager);

                // Update the tool to be moved (include update of the attached object if there is one)
                toolToMove.setToolToMove(sourceToolRow, dbManager, toolRack);

                // Update the information on the tip and box to load
                Box box = new Box();
                Tip tip = new Tip();

                loadBoxInfos(operationRow, box);
                loadTipInfos(operationRow, tip);

                // Setting the destination point.
                movementToDo.setTipToLoadPointAsDestination(box, tip, toolRack, toolToMove);

                // TODO : Create the commands to do the movements for each axis.
                commandsToSendList.Add("X" + movementToDo.desiredXPos.ToString());
                commandsToSendList.Add("Y" + movementToDo.desiredYPos.ToString());

                // TODO : HOME THE Z AXIS OF THE CONCERNED TOOL BEFORE STARTING
                // moveZ(concernedTool, 0) through CAN, 0 should be considered as the "Home" command

                // TODO : Send the command to move the Y and X axis 
                arduinoWorker.startWorker();
                arduinoWorker.write(commandsToSendList.First());
                commandsToSendList.RemoveAt(0);

                // TODO : LOAD THE TIP ON THE TOOL BY DROPPING Z TO THE CALCULATED VALUE IN movementToDo.
                // moveZ(concernedTool, movementToDo.desiredZPos) through CAN

                // TODO : UPDATE THE TOOL IN THE DATABASE TO MAKE SURE IT HAS THE REQUIRED OBJECT ATTACHED TO IT
                //        (add the attached object pk_id in fk_object of the tool to which it is attached)

                // TODO : Update the current position of the rack in the database (deck_x, deck_y)
            }
        }

        private void TrashTips(BioBotDataSets.bbt_operationRow operationRow)
        {
            if (operationRow.bbt_operation_typeRow.description == "Unload Tip")
            {
                BioBotDataSets.bbt_objectRow sourceToolRow = operationRow.bbt_stepRow.bbt_objectRow;

                // Get the latest tool rack position before starting the movement.
                toolRack.setToolRackPositions(dbManager);

                // Get the tool to be moved (include update of the attached object if there is one)
                toolToMove.setToolToMove(sourceToolRow, dbManager, toolRack);

                // Update the information on the tip and box to load
                Tip tip = new Tip();
                loadTipInfos(operationRow, tip);
                Trash trash = new Trash();                
                loadTrashInfos(operationRow, trash);

                // Setting the destination point.
                movementToDo.setTrashPointAsDestination(tip, trash, toolToMove);

                // TODO : Calculate the movements to be done for each axis.
                commandsToSendList.Add("X" + movementToDo.desiredXPos.ToString());
                commandsToSendList.Add("Y" + movementToDo.desiredYPos.ToString());

                // TODO : HOME THE Z AXIS OF THE CONCERNED TOOL BEFORE STARTING
                // moveZ(concernedTool, 0) through CAN, 0 should be considered as the "Home" command

                // TODO : Send the command to move the Y and X axis 
                arduinoWorker.startWorker();
                arduinoWorker.write(commandsToSendList.First());
                commandsToSendList.RemoveAt(0);

                // TODO : LOAD THE TIP ON THE TOOL BY DROPPING Z TO THE CALCULATED VALUE IN movementToDo.
                // moveZ(concernedTool, movementToDo.desiredZPos) through CAN

                // TODO : UPDATE THE TOOL IN THE DATABASE TO MAKE SURE IT HAS THE REQUIRED OBJECT ATTACHED TO IT
                //        (add the attached object pk_id in fk_object of the tool to which it is attached)

                // TODO : Update the current position of the rack in the database (deck_x, deck_y)
            }
        }

        private void moveToXYZ(BioBotDataSets.bbt_operationRow operationRow)
        {
            try
            {
                BioBotDataSets.bbt_stepRow stepToRun = operationRow.bbt_stepRow;
                BioBotDataSets.bbt_objectRow sourceToolRow = stepToRun.bbt_objectRow;

                // Update the tool rack position before starting the movement.
                toolRack.setToolRackPositions(dbManager);

                // Update the tool to be moved (include update of the attached object if there is one)
                toolToMove.setToolToMove(sourceToolRow, dbManager, toolRack);

                // Setting the destination point.
                movementToDo.setXYZAsDestination(operationRow, toolToMove);

                // TODO : Create the commands to do the movements for each axis.
                commandsToSendList.Add("X" + movementToDo.desiredXPos.ToString());
                commandsToSendList.Add("Y" + movementToDo.desiredYPos.ToString());

                // TODO : Send the command to move the Y and X axis 
                arduinoWorker.startWorker();
                arduinoWorker.write(commandsToSendList.First());
                commandsToSendList.RemoveAt(0);

                // TODO : Move the Z axis to the desired position :
                // moveZ(concernedTool, movementToDo.desiredZPos) through CAN

                // TODO : Update the current position of the rack in the database (deck_x, deck_y)
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); // REMOVE THE THROW LATER ON                
            }
        }

        private void loadBoxInfos(BioBotDataSets.bbt_operationRow operationRow, Box box)
        {
            BioBotDataSets.bbt_operation_referenceRow selectedOpRefBoxRow = operationRow.Getbbt_operation_referenceRows().Where(p => p.bbt_objectRow.bbt_object_typeRow.description == "Container").First();
            box.setBoxProperties(selectedOpRefBoxRow);
        }

        private void loadTipInfos(BioBotDataSets.bbt_operationRow operationRow, Tip tip)
        {
            BioBotDataSets.bbt_objectRow selectedTipRow = operationRow.Getbbt_operation_referenceRows().Where(p => p.bbt_objectRow.bbt_object_typeRow.description == "Tip").First().bbt_objectRow;
            tip.updateTipProperties(selectedTipRow);
        }

        private void loadTrashInfos(BioBotDataSets.bbt_operationRow operationRow, Trash trash)
        {
            BioBotDataSets.bbt_objectRow selectedTrashRow = operationRow.Getbbt_operation_referenceRows().Where(p => p.bbt_objectRow.bbt_object_typeRow.description == "Trash").First().bbt_objectRow;
            trash.setTrashProperties(selectedTrashRow);
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
        public int zToolZeroPos { get; set; }

        public int xLength { get; set; }
        public int yLength { get; set; }
        public int zLength { get; set; }
        public int radius { get; set; }       

        public ToolToMove()
        {
            isSet = false;
            toolType = new ToolType();
            attachedObject = new Object();
            zToolZeroPos = 0;
        }

        public void setToolToMove(BioBotDataSets.bbt_objectRow sourceToolRow, DBManager dbManager, ToolRack toolRack)
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

            // Get all objects attached to the source Tool (There should only be one):
            IEnumerable<BioBotDataSets.bbt_objectRow> attachedObjectsRows = sourceToolRow.Getbbt_objectRows();

            if (attachedObjectsRows.Any())
            {
                attachedObject.updateObject(attachedObjectsRows.First());
            }

            setToolOffsets(sourceToolRow, dbManager); 
            
            zToolZeroPos = toolRack.zPos - zToolRackOffset;

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
            if (row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "XLength" && p.bbt_propertyRow.bbt_property_typeRow.description == "Dimensions").Any())
            {
                int tempValue;
                int.TryParse(row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "XLength" && p.bbt_propertyRow.bbt_property_typeRow.description == "Dimensions").First().value, out tempValue);
                xLength = tempValue;
            }

            // Load the length on the Y axis of the object
            if (row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "YLength" && p.bbt_propertyRow.bbt_property_typeRow.description == "Dimensions").Any())
            {
                int tempValue;
                int.TryParse(row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "YLength" && p.bbt_propertyRow.bbt_property_typeRow.description == "Dimensions").First().value, out tempValue);
                yLength = tempValue;
            }

            // Load the length on the Z axis of the object
            if (row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "ZLength" && p.bbt_propertyRow.bbt_property_typeRow.description == "Dimensions").Any())
            {
                int tempValue;
                int.TryParse(row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "ZLength" && p.bbt_propertyRow.bbt_property_typeRow.description == "Dimensions").First().value, out tempValue);
                zLength = tempValue;
            }

            // Load the radius of the object
            if (row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "Radius" && p.bbt_propertyRow.bbt_property_typeRow.description == "Dimensions").Any())
            {
                int tempValue;
                int.TryParse(row.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "Radius" && p.bbt_propertyRow.bbt_property_typeRow.description == "Dimensions").First().value, out tempValue);
                radius = tempValue;
            }
        }
    }

    class Tip : Object
    {
        public int zBoxOffset { get; set; }
        public int zPipetteOffset { get; set; }
        public int xTrashDepthOffset { get; set; } // center to center

        public Tip()
        {
            isSet = false;
            zBoxOffset = 0;
            zPipetteOffset = 0;
            xTrashDepthOffset = 0;
        }

        public void updateTipProperties(BioBotDataSets.bbt_objectRow objectRow)
        {
            isSet = false;
            bool getGoing = true;

            while (getGoing == true)
            {
                updateObject(objectRow);

                int tempValue;

                getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "ContainerOffset").First().value, out tempValue);
                zBoxOffset = tempValue;

                getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "PipetteOffset").First().value, out tempValue);
                zPipetteOffset = tempValue;

                getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "TrashXDepthOffset").First().value, out tempValue);
                xTrashDepthOffset = tempValue;

                isSet = true;
            }            
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

        public void setBoxProperties(BioBotDataSets.bbt_operation_referenceRow operation_referenceRow)
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

    class Trash : Object
    {
        public int xFirstTrashWellOffset { get; set; }
        public int yFirstTrashWellOffset { get; set; }
        public int zFirstTrashWellOffset { get; set; }
        public int xPreTrashOffset { get; set; }
        public int xTrashOpenSpace { get; set; }

        public Trash()
        {
            isSet = false;
            xFirstTrashWellOffset = 0;
            yFirstTrashWellOffset = 0;
            zFirstTrashWellOffset = 0;
            xPreTrashOffset = 0;
            xTrashOpenSpace = 0;
        }

        public void setTrashProperties(BioBotDataSets.bbt_objectRow TrashRow)
        {
            updateObject(TrashRow);
            bool getGoing = true;
            while (getGoing == true)
            {
                int tempValue;

                getGoing = int.TryParse(TrashRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "FirstWellXOffset").First().value, out tempValue);
                xFirstTrashWellOffset = tempValue;

                getGoing = int.TryParse(TrashRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "FirstWellYOffset").First().value, out tempValue);
                yFirstTrashWellOffset = tempValue;

                getGoing = int.TryParse(TrashRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "FirstWellZOffset").First().value, out tempValue);
                zFirstTrashWellOffset = tempValue;

                getGoing = int.TryParse(TrashRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "PreTrashXOffset").First().value, out tempValue);
                zFirstTrashWellOffset = tempValue;

                getGoing = int.TryParse(TrashRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "TrashOpenSpace").First().value, out tempValue);
                zFirstTrashWellOffset = tempValue;

                isSet = true;
                break;
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
        public const int ADDED_BOX_PENETRATION_DEEPNESS = 30; // Represents 3mm.
        public const int ADDED_TRASH_PENETRATION_DEEPNESS = 10; // Represents 1mm.

        public int desiredXPos { get; set; }
        public int desiredYPos { get; set; }
        public int desiredZPos { get; set; } 
        
        public bool isStartingPointSet { get; set; }
        public bool isDestinationPointSet { get; set; }

        public Movement()
        {
            desiredXPos = 0;
            desiredYPos = 0;
            desiredZPos = 0;

            isDestinationPointSet = false;
            isStartingPointSet = false;
        }
        
        public void setTipToLoadPointAsDestination(Box box, Tip tip, ToolRack toolRack, ToolToMove tool)
        {
            if (box.isSet == true && tip.isSet == true && tool.isSet == true && tool.hasAttachedObject == false)
            {
                int tipAndBoxHeight = box.zLength + tip.zBoxOffset;
                int penetrationDeepness = tip.zLength - tip.zPipetteOffset;                                      

                desiredZPos = tool.zToolZeroPos - (tipAndBoxHeight - penetrationDeepness - ADDED_BOX_PENETRATION_DEEPNESS);
                
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
        }

        public void setTrashPointAsDestination(Tip tip, Trash trash, ToolToMove tool)
        {            
            // The trash metal part must be placed on trash's closest side to the home of the robot on the X axis.
            desiredXPos = trash.xDeckPos + trash.xFirstTrashWellOffset - Math.Abs(tip.xTrashDepthOffset);
            desiredYPos = trash.yDeckPos + trash.yFirstTrashWellOffset;
            desiredZPos = tool.zToolZeroPos - (trash.zFirstTrashWellOffset-(tip.zLength-tip.zPipetteOffset)-ADDED_TRASH_PENETRATION_DEEPNESS);         
        }

        public void setXYZAsDestination(BioBotDataSets.bbt_operationRow operationRow, ToolToMove tool)
        {
            int tempValue = 0;
            int.TryParse(operationRow.Getbbt_operation_referenceRows().First().Getbbt_operation_reference_propertyRows().Where(p => p.bbt_propertyRow.description == "xDestination" && p.bbt_propertyRow.bbt_property_typeRow.description == "DestinationPoint").First().value, out tempValue);
            desiredXPos = tempValue;

            int.TryParse(operationRow.Getbbt_operation_referenceRows().First().Getbbt_operation_reference_propertyRows().Where(p => p.bbt_propertyRow.description == "yDestination" && p.bbt_propertyRow.bbt_property_typeRow.description == "DestinationPoint").First().value, out tempValue);
            desiredYPos = tempValue;

            int.TryParse(operationRow.Getbbt_operation_referenceRows().First().Getbbt_operation_reference_propertyRows().Where(p => p.bbt_propertyRow.description == "xDestination" && p.bbt_propertyRow.bbt_property_typeRow.description == "DestinationPoint").First().value, out tempValue);
            desiredZPos = tool.zToolZeroPos - tempValue; // Changes the reference point according to the tool from it's tool rack offsets
        }
    }

    public enum ToolType { Gripper, SingleChannelPipette, MultipleChannelPipette };   
}
