﻿using BioBotApp.Model.Data;
using BioBotCommunication.Serial.Can;
using BioBotCommunication.Serial.Movement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BioBotApp.Model.Data.Services;
using BioBotApp.Model.Sequencer.Helpers;

namespace BioBotApp.Model.Movement
{
    class MovementAlgorithm : Model.EventBus.Subscriber, ICommand
    {
        DBManager dbManager;              
        CANCommunicationWorker canWorker;
        Model.Communication.CommunicationService communicationService;

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
            communicationService = Model.Communication.CommunicationService.Instance;
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

        [Model.EventBus.Subscribe]
        public void onExecuteEvent(Model.EventBus.Events.ExecutionService.ExecutionEvent e)
        {
            Model.Data.BioBotDataSets.bbt_operationRow row = e.operationRow;
            if (row == null) return;
            BioBotDataSets.bbt_stepRow stepRow = row.bbt_stepRow;
            Move(e.operationRow);

            /*
            if (stepRow.fk_object == OBJECT_ID)
            {
                Console.WriteLine("Single channel pipette step execute: " + stepRow.description);
                EventBus.Instance.post(new Model.Sequencer.Events.ExecuteCommandEvent(this));
            }
            if (row.Getbbt_operation_referenceRows().Length > 0)
            {

                foreach (BioBotDataSets.bbt_operation_referenceRow referenceRow in row.Getbbt_operation_referenceRows())
                {
                    if (referenceRow.fk_object == OBJECT_ID)
                    {
                        Console.WriteLine("Single channel pipette operation execute: " + row.bbt_operation_typeRow.description);
                        Model.EventBus.Instance.post(new Model.Sequencer.Events.ExecuteCommandEvent(this));
                    }
                }
            }
            /**/
        }

        public void writeData(String data)
        {
            communicationService.writeData(data);
            Model.EventBus.EventBus.Instance.post(new Model.Sequencer.Events.ExecuteCommandEvent(this));
        }

        [Model.EventBus.Subscribe]
        public void OnMessageReceived(BioBotCommunication.Serial.Events.OnCommunicationMessageReceived e)
        {
            Model.EventBus.EventBus.Instance.post(new Model.Sequencer.Events.CompletionCommandEvent(this));
        }

        public int Move(BioBotDataSets.bbt_operationRow operationRow)
        {

            if (operationRow.bbt_operation_typeRow.description == "Move To Object")
            {
                // To be done
            }
            else if (operationRow.bbt_operation_typeRow.description == "Load Tip")
            {
                GetTips(operationRow);
            }
            else if (operationRow.bbt_operation_typeRow.description == "Unload Tip")
            {
                TrashTips(operationRow);
            }
            else if (operationRow.bbt_operation_typeRow.description == "Move To X")
            {
                moveToX(operationRow);
            }
            else if (operationRow.bbt_operation_typeRow.description == "Move To Y")
            {
                moveToY(operationRow);
            }
            else if (operationRow.bbt_operation_typeRow.description == "Move To Z")
            {
                moveToZ(operationRow);
            }
            else
            {
                return -1;
            }
            return 1;
        }

        private void moveToX(BioBotDataSets.bbt_operationRow operationRow)
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
                movementToDo.setXAsDestination(toolToMove, operationRow);              

                // TODO : Create the commands to do the movements for each axis.
                commandsToSendList.Add("X" + movementToDo.desiredXPos.ToString());

                // TODO : Send the command to move the X axis                
                writeData(commandsToSendList.First());
                commandsToSendList.RemoveAt(0);

                // TODO : Update the current position of the rack in the database (deck_x, deck_y)
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); // REMOVE THE THROW LATER ON                
            }
        }

        private void moveToY(BioBotDataSets.bbt_operationRow operationRow)
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
                movementToDo.setYAsDestination(toolToMove, operationRow);

                // TODO : Create the commands to do the movements for each axis.
                commandsToSendList.Add("Y" + movementToDo.desiredYPos.ToString());

                // TODO : Send the command to move the Y axis 
                writeData(commandsToSendList.First());
                commandsToSendList.RemoveAt(0);

                // TODO : Update the current position of the rack in the database (deck_x, deck_y)
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); // REMOVE THE THROW LATER ON                
            }
        }

        private void moveToZ(BioBotDataSets.bbt_operationRow operationRow)
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
                movementToDo.setZAsDestination(toolToMove, operationRow);

                // TODO : Create the commands to do the movements for each axis.
                commandsToSendList.Add("Z" + toolToMove.zAxisNumber + " " + movementToDo.desiredYPos.ToString());

                // TODO : Send the command to move the Z axis 
                writeData(commandsToSendList.First());
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

        private void GetTips(BioBotDataSets.bbt_operationRow operationRow)
        {
            BioBotDataSets.bbt_stepRow stepToRun = operationRow.bbt_stepRow;
            BioBotDataSets.bbt_objectRow sourceToolRow = stepToRun.bbt_objectRow;

            // Update the tool rack position before starting the movement.
            //toolRack.setToolRackPositions(dbManager);

            // Update the tool to be moved (include update of the attached object if there is one)
            toolToMove.setToolToMove(sourceToolRow, dbManager, toolRack);

            // Update the information on the tip and box to load
            Box box = new Box();
            Tip tip = new Tip();

            box.setBoxProperties(operationRow);
            tip.updateTipProperties(operationRow);

            // Setting the destination point.
            movementToDo.setTipToLoadPointAsDestination(box, tip, toolToMove);

            // TODO : Create the commands to do the movements for each axis.
            commandsToSendList.Add("X" + movementToDo.desiredXPos.ToString());
            commandsToSendList.Add("Y" + movementToDo.desiredYPos.ToString());

            // TODO : HOME THE Z AXIS OF THE CONCERNED TOOL BEFORE STARTING
            // moveZ(concernedTool, 0) through CAN, 0 should be considered as the "Home" command

            // TODO : Send the command to move the Y and X axis 
            writeData(commandsToSendList.First());
            commandsToSendList.RemoveAt(0);

            // TODO : LOAD THE TIP ON THE TOOL BY DROPPING Z TO THE CALCULATED VALUE IN movementToDo.
            // moveZ(concernedTool, movementToDo.desiredZPos) through CAN

            // TODO : UPDATE THE TOOL IN THE DATABASE TO MAKE SURE IT HAS THE REQUIRED OBJECT ATTACHED TO IT
            //        (add the attached object pk_id in fk_object of the tool to which it is attached)

            // TODO : Update the current position of the rack in the database (deck_x, deck_y)
        }

        private void TrashTips(BioBotDataSets.bbt_operationRow operationRow)
        {
            if (operationRow.bbt_operation_typeRow.description == "Unload Tip")
            {
                BioBotDataSets.bbt_objectRow sourceToolRow = operationRow.bbt_stepRow.bbt_objectRow;
                
                // Get the tool to be moved (include update of the attached object if there is one)
                toolToMove.setToolToMove(sourceToolRow, dbManager, toolRack);

                // Update the information on the tip and box to load
                Tip tip = new Tip();
                tip.updateTipProperties(operationRow);                
                Trash trash = new Trash();
                trash.setTrashProperties(operationRow); 
                
                // Setting the destination point.
                movementToDo.setTrashPointAsDestination(tip, trash, toolToMove);

                // TODO : Calculate the movements to be done for each axis.
                commandsToSendList.Add("X" + movementToDo.desiredXPos.ToString());
                commandsToSendList.Add("Y" + movementToDo.desiredYPos.ToString());

                // TODO : HOME THE Z AXIS OF THE CONCERNED TOOL BEFORE STARTING
                // moveZ(concernedTool, 0) through CAN, 0 should be considered as the "Home" command

                // TODO : Send the command to move the Y and X axis 
                writeData(commandsToSendList.First());
                commandsToSendList.RemoveAt(0);

                // TODO : LOAD THE TIP ON THE TOOL BY DROPPING Z TO THE CALCULATED VALUE IN movementToDo.
                // moveZ(concernedTool, movementToDo.desiredZPos) through CAN

                // TODO : UPDATE THE TOOL IN THE DATABASE TO MAKE SURE IT HAS THE REQUIRED OBJECT ATTACHED TO IT
                //        (add the attached object pk_id in fk_object of the tool to which it is attached)

                // TODO : Update the current position of the rack in the database (deck_x, deck_y)
            }
        }        

        private void Worker_onArduinoReceive(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            writeData(commandsToSendList.First());
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
            xPos = 0;
            yPos = 0;
            zPos = 0;

            setToolRackPositions(dbManager);            
        }

        public bool setToolRackPositions(DBManager dbManager)
        {
            string informationValue = InformationValueService.Instance.getInformationValue("ToolRackPosition", "Z");
            
            int tempValue;

            if (int.TryParse(informationValue, out tempValue))
            {
                zPos = tempValue;
                return true;
            }
            else
            {
                return false;
            }
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

        public int xLength { get; set; }
        public int yLength { get; set; }
        public int zLength { get; set; }
        public int radius { get; set; }

        public int xToolRackOffset { get; set; }
        public int yToolRackOffset { get; set; }
        public int zToolRackOffset { get; set; }
        public int zToolZeroPos { get; set; }  
        public int zAxisNumber { get; set; } 

        public ToolToMove()
        {
            isSet = false;
            toolType = new ToolType();
            attachedObject = new Object();
            zToolZeroPos = 0;
            zAxisNumber = 0;
        }

        public void setToolToMove(BioBotDataSets.bbt_objectRow sourceToolRow, DBManager dbManager, ToolRack toolRack)
        {
            // Setting the Tool Type :
            if (sourceToolRow.bbt_object_typeRow.description == "Single Channel Pipette")
            {
                toolType = ToolType.SingleChannelPipette;
                zAxisNumber = 1;
            }
            else if (sourceToolRow.bbt_object_typeRow.description == "Multiple Channel Pipette")
            {
                toolType = ToolType.MultipleChannelPipette;
                zAxisNumber = 2;
            }
            else if (sourceToolRow.bbt_object_typeRow.description == "Gripper")
            {
                toolType = ToolType.Gripper;
                zAxisNumber = 3;
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
            string tempString;
            tempString = ObjectPropertyService.Instance.getObjectPropertyValue("XLength", "Dimension", row.bbt_object_typeRow.pk_id);
            if (tempString != "")
            {
                int tempValue;
                int.TryParse(tempString, out tempValue);
                xLength = tempValue;
            }

            // Load the length on the Y axis of the object
            tempString = ObjectPropertyService.Instance.getObjectPropertyValue("YLength", "Dimension", row.bbt_object_typeRow.pk_id);
            if (tempString != "")
            {
                int tempValue;
                int.TryParse(tempString, out tempValue);            
                yLength = tempValue;
            }

            // Load the length on the Z axis of the object
            tempString = ObjectPropertyService.Instance.getObjectPropertyValue("ZLength", "Dimension", row.bbt_object_typeRow.pk_id);
            if (tempString != "")
            {
                int tempValue;
                int.TryParse(tempString, out tempValue);
                zLength = tempValue;
            }

            // Load the radius of the object
            tempString = ObjectPropertyService.Instance.getObjectPropertyValue("Radius", "Dimension", row.bbt_object_typeRow.pk_id);
            if (tempString != "")
            {
                int tempValue;
                int.TryParse(tempString, out tempValue);
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

        public bool isSet { get; set; }

        public Object()
        {
            isSet = false;            
        }

        public void updateObject(BioBotDataSets.bbt_objectRow row)
        {            
            xDeckPos = row.deck_x;
            yDeckPos = row.deck_y;

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
            string tempString;
            tempString = ObjectPropertyService.Instance.getObjectPropertyValue("XLength", "Dimension", row.bbt_object_typeRow.pk_id);
            if (tempString != "")
            {
                int tempValue;
                int.TryParse(tempString, out tempValue);
                xLength = tempValue;
            }

            // Load the length on the Y axis of the object
            tempString = ObjectPropertyService.Instance.getObjectPropertyValue("YLength", "Dimension", row.bbt_object_typeRow.pk_id);
            if (tempString != "")
            {
                int tempValue;
                int.TryParse(tempString, out tempValue);
                yLength = tempValue;
            }

            // Load the length on the Z axis of the object
            tempString = ObjectPropertyService.Instance.getObjectPropertyValue("ZLength", "Dimension", row.bbt_object_typeRow.pk_id);
            if (tempString != "")
            {
                int tempValue;
                int.TryParse(tempString, out tempValue);
                zLength = tempValue;
            }

            // Load the radius of the object
            tempString = ObjectPropertyService.Instance.getObjectPropertyValue("Radius", "Dimension", row.bbt_object_typeRow.pk_id);
            if (tempString != "")
            {
                int tempValue;
                int.TryParse(tempString, out tempValue);
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

        public void updateTipProperties(BioBotDataSets.bbt_operationRow operationRow)
        {
            BioBotDataSets.bbt_objectRow objectRow = operationRow.Getbbt_operation_referenceRows().Where(p => p.bbt_objectRow.bbt_object_typeRow.description.StartsWith("Tip")).First().bbt_objectRow;
            
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

        public void setBoxProperties(BioBotDataSets.bbt_operationRow operationRow)
        {
            BioBotDataSets.bbt_operation_referenceRow operation_referenceRow = operationRow.Getbbt_operation_referenceRows().Where(p => p.bbt_objectRow.bbt_object_typeRow.description.StartsWith("Container")).First();

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

                getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "X" && p.bbt_propertyRow.bbt_property_typeRow.description == "WellOffset").First().value, out tempValue);
                xWellOffset = tempValue;
                
                getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "Y" && p.bbt_propertyRow.bbt_property_typeRow.description == "WellOffset").First().value, out tempValue);
                yWellOffset = tempValue;

                // Test to see what is in the database :
                IEnumerable<BioBotDataSets.bbt_operation_reference_propertyRow> asdf = operation_referenceRow.Getbbt_operation_reference_propertyRows();
                BioBotDataSets.bbt_operation_reference_propertyDataTable a = DBManager.Instance.projectDataset.bbt_operation_reference_property;
                // End of test section.

                //getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "ChosenWell" && p.bbt_propertyRow.bbt_property_typeRow.description == "WellProperties").First().value, out tempValue);
                if (operation_referenceRow.Getbbt_operation_reference_propertyRows().Where(p => p.bbt_propertyRow.description == "ChosenWell").Any())
                {
                    getGoing = int.TryParse(operation_referenceRow.Getbbt_operation_reference_propertyRows().Where(p => p.bbt_propertyRow.description == "ChosenWell").First().value, out tempValue);
                    chosenWell = tempValue;
                }
                else if (operation_referenceRow.Getbbt_operation_reference_propertyRows().Where(p => p.bbt_propertyRow.description == "ChosenWellRow").Any())
                {
                    //getGoing = int.TryParse(objectRow.bbt_object_typeRow.Getbbt_object_propertyRows().Where(p => p.bbt_propertyRow.description == "ChosenWellRow" && p.bbt_propertyRow.bbt_property_typeRow.description == "WellProperties").First().value, out tempValue);
                    getGoing = int.TryParse(operation_referenceRow.Getbbt_operation_reference_propertyRows().Where(p => p.bbt_propertyRow.description == "ChosenWellRow").First().value, out tempValue);
                    chosenWellRow = tempValue;
                }                            

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

        public Trash()
        {
            isSet = false;
            xFirstTrashWellOffset = 0;
            yFirstTrashWellOffset = 0;
            zFirstTrashWellOffset = 0;
            xPreTrashOffset = 0;
        }

        public void setTrashProperties(BioBotDataSets.bbt_operationRow operationRow)
        {
            BioBotDataSets.bbt_objectRow TrashRow = operationRow.Getbbt_operation_referenceRows().Where(p => p.bbt_objectRow.bbt_object_typeRow.description == "Trash").First().bbt_objectRow;

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
                xPreTrashOffset = tempValue;

                isSet = true;
                break;
            }
        }
    }    

    class CommandToSend
    {
        public CommandType cmdType { get; set; }
        public String SerialMsgToSend { get; set; }
    }   

    class Movement
    {
        public const int ADDED_BOX_PENETRATION_DEEPNESS = 30; // Represents 3mm.
        public const int ADDED_TRASH_PENETRATION_DEEPNESS = 10; // Represents 1mm.
        bool movementCandBeDone = false;

        public int desiredXPos { get; set; }
        public int desiredYPos { get; set; }
        public int desiredZPos { get; set; } 

        public bool isDestinationPointSet { get; set; }

        public Movement()
        {
            desiredXPos = 0;
            desiredYPos = 0;
            desiredZPos = 0;

            isDestinationPointSet = false;
        }
        
        public void setTipToLoadPointAsDestination(Box box, Tip tip, ToolToMove tool)
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
                    desiredXPos = tempX + (int)Math.Floor((double)box.chosenWellRow * box.xWellOffset);
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

        public void setXAsDestination(ToolToMove tool, BioBotDataSets.bbt_operationRow operationRow)
        {
            int desiredXPosition = 0;
            int tempValue = 0;

            if (int.TryParse(operationRow.value, out tempValue))
            {
                desiredXPosition = tempValue;

                desiredXPos = desiredXPosition - tool.xToolRackOffset;

                if (desiredXPos > 0)
                    movementCandBeDone = true;
            }
            else
            {
                movementCandBeDone = false;
            }           
        }

        public void setYAsDestination(ToolToMove tool, BioBotDataSets.bbt_operationRow operationRow)
        {
            int desiredYPosition = 0;
            int tempValue = 0;

            if (int.TryParse(operationRow.value, out tempValue))
            {
                desiredYPosition = tempValue;

                desiredYPos = desiredYPosition - tool.yToolRackOffset;

                if (desiredYPos > 0)
                    movementCandBeDone = true;
            }
            else
            {
                movementCandBeDone = false;
            }
        }

        public void setZAsDestination(ToolToMove tool, BioBotDataSets.bbt_operationRow operationRow)
        {
            int desiredZPosition = 0;
            int tempValue = 0;

            if (int.TryParse(operationRow.value, out tempValue))
            {
                desiredZPosition = tempValue;

                desiredZPos = desiredZPosition - tool.zToolRackOffset;

                if (desiredZPos > 0)
                    movementCandBeDone = true;
            }
            else
            {
                movementCandBeDone = false;
            }
        }


        public void setXYZAsDestination(BioBotDataSets.bbt_operationRow operationRow, ToolToMove tool)
        {

            int tempValue = 0;
            int.TryParse(operationRow.Getbbt_operation_referenceRows().First().Getbbt_operation_reference_propertyRows().Where(p => p.bbt_propertyRow.description == "xDestination" && p.bbt_propertyRow.bbt_property_typeRow.description == "DestinationPoint").First().value, out tempValue);
            desiredXPos = tempValue;

            int.TryParse(operationRow.Getbbt_operation_referenceRows().First().Getbbt_operation_reference_propertyRows().Where(p => p.bbt_propertyRow.description == "yDestination" && p.bbt_propertyRow.bbt_property_typeRow.description == "DestinationPoint").First().value, out tempValue);
            desiredYPos = tempValue;

            int.TryParse(operationRow.Getbbt_operation_referenceRows().First().Getbbt_operation_reference_propertyRows().Where(p => p.bbt_propertyRow.description == "zDestination" && p.bbt_propertyRow.bbt_property_typeRow.description == "DestinationPoint").First().value, out tempValue);
            desiredZPos = tool.zToolZeroPos - tempValue; // Changes the reference point according to the tool from it's tool rack offsets
        }
    }

    public enum CommandType { CAN, SERIAL }

    public enum ToolType { Gripper, SingleChannelPipette, MultipleChannelPipette };   
}