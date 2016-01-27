--
-- PostgreSQL database dump
--

-- Dumped from database version 9.3.10
-- Dumped by pg_dump version 9.5rc1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

SET search_path = deck, pg_catalog;

--
-- Data for Name: bbt_object_type; Type: TABLE DATA; Schema: deck; Owner: biobot
--

INSERT INTO bbt_object_type VALUES (1, 'TAC');
INSERT INTO bbt_object_type VALUES (2, 'MC96');
INSERT INTO bbt_object_type VALUES (4, 'PCR96');
INSERT INTO bbt_object_type VALUES (8, 'Deck');
INSERT INTO bbt_object_type VALUES (10, '96 Wells');
INSERT INTO bbt_object_type VALUES (11, '25mm Tube');
INSERT INTO bbt_object_type VALUES (3, 'MC1.5');
INSERT INTO bbt_object_type VALUES (12, '1.5mm Tube');
INSERT INTO bbt_object_type VALUES (9, 'Centrifuge');
INSERT INTO bbt_object_type VALUES (7, 'Gripper');
INSERT INTO bbt_object_type VALUES (13, 'ToolRack');
INSERT INTO bbt_object_type VALUES (5, 'Single Channel Pipette');
INSERT INTO bbt_object_type VALUES (6, 'Multiple Channel Pipette');
INSERT INTO bbt_object_type VALUES (0, 'None');
INSERT INTO bbt_object_type VALUES (17, 'Trash');
INSERT INTO bbt_object_type VALUES (14, 'Tip P1000');
INSERT INTO bbt_object_type VALUES (15, 'Tip P200');
INSERT INTO bbt_object_type VALUES (16, 'Tip P100');
INSERT INTO bbt_object_type VALUES (18, 'Container Box1000');
INSERT INTO bbt_object_type VALUES (19, 'Container Box200');
INSERT INTO bbt_object_type VALUES (20, 'Container Box100');
INSERT INTO bbt_object_type VALUES (21, 'Support BoxP100');
INSERT INTO bbt_object_type VALUES (22, 'Peg Board');


--
-- Data for Name: bbt_object; Type: TABLE DATA; Schema: deck; Owner: biobot
--

INSERT INTO bbt_object VALUES (26, 18, 8000, 6000, 180, true, 'Box1', 12, 0);
INSERT INTO bbt_object VALUES (2, 1, 10000, 2000, 0, true, 'Tac1', 0, 0);
INSERT INTO bbt_object VALUES (3, 3, 5000, 5000, 0, true, 'mc1.5', 0, 0);
INSERT INTO bbt_object VALUES (21, 19, 12004, 2031, 180, false, 'Box200 2', 12, 0);
INSERT INTO bbt_object VALUES (24, 19, 9500, 6000, 180, false, 'Box200 5', 12, 0);
INSERT INTO bbt_object VALUES (27, 18, 8000, 7000, 180, false, 'Box1000 7', 12, 0);
INSERT INTO bbt_object VALUES (14, 21, 8000, 8000, 0, true, 'Support well', 0, 0);
INSERT INTO bbt_object VALUES (10, 10, 8622, 5562, 270, false, '96 Well', 14, 0);
INSERT INTO bbt_object VALUES (25, 19, 7178, 6095, 180, false, 'Box200 6', 12, 0);
INSERT INTO bbt_object VALUES (20, 19, 4490, 1591, 90, true, 'Box200 1', 12, 0);
INSERT INTO bbt_object VALUES (0, NULL, 0, 0, 0, false, 'None', 0, 0);
INSERT INTO bbt_object VALUES (1, 8, NULL, NULL, NULL, true, 'Deck', 0, 0);
INSERT INTO bbt_object VALUES (5, 18, 1256, 4420, 270, true, 'Box1000', 12, 0);
INSERT INTO bbt_object VALUES (6, 13, NULL, NULL, 0, true, 'ToolRack', 0, 0);
INSERT INTO bbt_object VALUES (7, 5, NULL, NULL, 0, true, 'Single Channel Pipette', 0, 0);
INSERT INTO bbt_object VALUES (12, 21, 11000, 5000, 90, true, 'support pipette', 0, 0);
INSERT INTO bbt_object VALUES (33, 20, 13500, 5800, 0, true, 'Box10 6', 12, 0);
INSERT INTO bbt_object VALUES (31, 20, 13500, 3600, 0, true, 'Box10 4', 12, 0);
INSERT INTO bbt_object VALUES (32, 20, 13500, 4800, 0, true, 'Box10 5', 12, 0);
INSERT INTO bbt_object VALUES (30, 20, 13500, 2600, 0, true, 'Box10 3', 12, 0);
INSERT INTO bbt_object VALUES (29, 20, 13500, 1400, 0, true, 'Box10 2', 12, 0);
INSERT INTO bbt_object VALUES (28, 20, 13500, 400, 0, true, 'Box10 1', 12, 0);
INSERT INTO bbt_object VALUES (15, 14, NULL, NULL, NULL, true, 'Tip1000', 0, 0);
INSERT INTO bbt_object VALUES (8, 4, 5000, 10000, 0, false, 'PCR96', 0, 0);
INSERT INTO bbt_object VALUES (34, 1, 200, 1250, 0, true, 'TAC 2', 0, NULL);
INSERT INTO bbt_object VALUES (23, 19, 9500, 5000, 180, true, 'Box200 4', 12, 0);
INSERT INTO bbt_object VALUES (22, 19, 9500, 4000, 180, true, 'Box200 3', 12, 0);
INSERT INTO bbt_object VALUES (19, 18, 8000, 5000, 180, true, 'Box4', 12, 0);
INSERT INTO bbt_object VALUES (18, 18, 8000, 4000, 180, true, 'Box3', 12, 0);
INSERT INTO bbt_object VALUES (17, 18, 8000, 3000, 180, true, 'Box2 1000', 12, 0);
INSERT INTO bbt_object VALUES (16, 17, 2000, 2000, 0, true, 'Trash', 0, 0);
INSERT INTO bbt_object VALUES (4, 3, 10000, 1000, 0, true, 'm1.5 2', 0, 0);


--
-- Data for Name: bbt_property_type; Type: TABLE DATA; Schema: deck; Owner: biobot
--

INSERT INTO bbt_property_type VALUES (1, 'Dimension');
INSERT INTO bbt_property_type VALUES (0, 'Nothing');
INSERT INTO bbt_property_type VALUES (3, 'WellCount');
INSERT INTO bbt_property_type VALUES (2, 'WellProperties');
INSERT INTO bbt_property_type VALUES (5, 'WellOffset');
INSERT INTO bbt_property_type VALUES (6, 'ToolRackOffset');
INSERT INTO bbt_property_type VALUES (7, 'ReferencePosition');
INSERT INTO bbt_property_type VALUES (8, 'ToolRackPosition');
INSERT INTO bbt_property_type VALUES (9, 'TrashProperties');
INSERT INTO bbt_property_type VALUES (4, 'FirstWell');
INSERT INTO bbt_property_type VALUES (14, 'SupportOffset');
INSERT INTO bbt_property_type VALUES (10, 'PegHoleOffset');
INSERT INTO bbt_property_type VALUES (23, 'DestinationPoint');
INSERT INTO bbt_property_type VALUES (12, 'FirstPegHoleOffset');
INSERT INTO bbt_property_type VALUES (13, 'PegHoleCount');
INSERT INTO bbt_property_type VALUES (24, 'ToolRackHomeOffset');


--
-- Data for Name: bbt_property; Type: TABLE DATA; Schema: deck; Owner: biobot
--

INSERT INTO bbt_property VALUES (20, 'X', 8);
INSERT INTO bbt_property VALUES (21, 'Y', 8);
INSERT INTO bbt_property VALUES (22, 'Z', 8);
INSERT INTO bbt_property VALUES (25, 'Grippable', 0);
INSERT INTO bbt_property VALUES (26, 'Radius', 1);
INSERT INTO bbt_property VALUES (27, 'CanDeckLayout', 0);
INSERT INTO bbt_property VALUES (28, 'FirstWellXOffset', 9);
INSERT INTO bbt_property VALUES (29, 'FirstWellYOffset', 9);
INSERT INTO bbt_property VALUES (30, 'FirstWellZOffset', 9);
INSERT INTO bbt_property VALUES (31, 'PreTrashXOffset', 9);
INSERT INTO bbt_property VALUES (4, 'XOffset', 4);
INSERT INTO bbt_property VALUES (5, 'YOffset', 4);
INSERT INTO bbt_property VALUES (8, 'Total', 3);
INSERT INTO bbt_property VALUES (24, 'PipetteOffset', 0);
INSERT INTO bbt_property VALUES (23, 'ContainerOffset', 0);
INSERT INTO bbt_property VALUES (32, 'ChosenWell', NULL);
INSERT INTO bbt_property VALUES (33, 'ChosenWellRow', NULL);
INSERT INTO bbt_property VALUES (11, 'WellDepth', 2);
INSERT INTO bbt_property VALUES (12, 'WellShape', 2);
INSERT INTO bbt_property VALUES (13, 'WellBottomShape', 2);
INSERT INTO bbt_property VALUES (14, 'WellMaxVolume', 2);
INSERT INTO bbt_property VALUES (37, 'X', 10);
INSERT INTO bbt_property VALUES (38, 'Y', 10);
INSERT INTO bbt_property VALUES (39, 'Total', 13);
INSERT INTO bbt_property VALUES (40, 'X', 13);
INSERT INTO bbt_property VALUES (41, 'Y', 13);
INSERT INTO bbt_property VALUES (42, 'X', 14);
INSERT INTO bbt_property VALUES (43, 'Y', 14);
INSERT INTO bbt_property VALUES (6, 'X', 5);
INSERT INTO bbt_property VALUES (7, 'Y', 5);
INSERT INTO bbt_property VALUES (1, 'XLength', 1);
INSERT INTO bbt_property VALUES (2, 'YLength', 1);
INSERT INTO bbt_property VALUES (3, 'ZLength', 1);
INSERT INTO bbt_property VALUES (17, 'X', 6);
INSERT INTO bbt_property VALUES (18, 'Y', 6);
INSERT INTO bbt_property VALUES (19, 'Z', 6);
INSERT INTO bbt_property VALUES (9, 'XCount', 3);
INSERT INTO bbt_property VALUES (10, 'YCount', 3);
INSERT INTO bbt_property VALUES (35, 'Y', 12);
INSERT INTO bbt_property VALUES (34, 'X', 12);
INSERT INTO bbt_property VALUES (50, 'xDestination', 23);
INSERT INTO bbt_property VALUES (15, 'XRef', 7);
INSERT INTO bbt_property VALUES (16, 'YRef', 7);
INSERT INTO bbt_property VALUES (51, 'yDestination', 23);
INSERT INTO bbt_property VALUES (52, 'zDestination', 23);
INSERT INTO bbt_property VALUES (0, 'None', 0);
INSERT INTO bbt_property VALUES (55, 'TrashXDepthOffset', 0);
INSERT INTO bbt_property VALUES (58, 'X', 24);
INSERT INTO bbt_property VALUES (59, 'Y', 24);
INSERT INTO bbt_property VALUES (60, 'Z', 24);


--
-- Data for Name: bbt_information_value; Type: TABLE DATA; Schema: deck; Owner: biobot
--

INSERT INTO bbt_information_value VALUES (1, 0, 22, 6, '4650');
INSERT INTO bbt_information_value VALUES (0, 0, 0, 0, 'None');
INSERT INTO bbt_information_value VALUES (4, 0, 19, 7, '-640');
INSERT INTO bbt_information_value VALUES (2, 0, 17, 7, '-700');
INSERT INTO bbt_information_value VALUES (3, 0, 18, 7, '400');


--
-- Name: bbt_information_value_pk_id_seq; Type: SEQUENCE SET; Schema: deck; Owner: biobot
--

SELECT pg_catalog.setval('bbt_information_value_pk_id_seq', 5, true);


--
-- Name: bbt_object_pk_id_seq; Type: SEQUENCE SET; Schema: deck; Owner: biobot
--

SELECT pg_catalog.setval('bbt_object_pk_id_seq', 34, true);


--
-- Data for Name: bbt_object_property; Type: TABLE DATA; Schema: deck; Owner: biobot
--

INSERT INTO bbt_object_property VALUES (10, 8, '96');
INSERT INTO bbt_object_property VALUES (14, 24, '525');
INSERT INTO bbt_object_property VALUES (15, 24, '317');
INSERT INTO bbt_object_property VALUES (16, 26, '30');
INSERT INTO bbt_object_property VALUES (19, 25, '1');
INSERT INTO bbt_object_property VALUES (19, 1, '1190');
INSERT INTO bbt_object_property VALUES (10, 10, '8');
INSERT INTO bbt_object_property VALUES (18, 9, '12');
INSERT INTO bbt_object_property VALUES (1, 27, '1');
INSERT INTO bbt_object_property VALUES (3, 27, '1');
INSERT INTO bbt_object_property VALUES (2, 27, '1');
INSERT INTO bbt_object_property VALUES (4, 27, '1');
INSERT INTO bbt_object_property VALUES (5, 27, '0');
INSERT INTO bbt_object_property VALUES (6, 27, '0');
INSERT INTO bbt_object_property VALUES (7, 27, '0');
INSERT INTO bbt_object_property VALUES (16, 24, '360');
INSERT INTO bbt_object_property VALUES (1, 1, '895');
INSERT INTO bbt_object_property VALUES (1, 2, '964');
INSERT INTO bbt_object_property VALUES (1, 3, '1712');
INSERT INTO bbt_object_property VALUES (3, 1, '635');
INSERT INTO bbt_object_property VALUES (3, 2, '854');
INSERT INTO bbt_object_property VALUES (3, 3, '1702');
INSERT INTO bbt_object_property VALUES (4, 1, '1492');
INSERT INTO bbt_object_property VALUES (4, 2, '1495');
INSERT INTO bbt_object_property VALUES (4, 3, '1697');
INSERT INTO bbt_object_property VALUES (5, 1, '790');
INSERT INTO bbt_object_property VALUES (5, 2, '1010');
INSERT INTO bbt_object_property VALUES (5, 3, '7360');
INSERT INTO bbt_object_property VALUES (5, 15, '140');
INSERT INTO bbt_object_property VALUES (5, 16, '400');
INSERT INTO bbt_object_property VALUES (8, 2, '10000');
INSERT INTO bbt_object_property VALUES (8, 3, '4700');
INSERT INTO bbt_object_property VALUES (10, 1, '855');
INSERT INTO bbt_object_property VALUES (10, 2, '1278');
INSERT INTO bbt_object_property VALUES (10, 3, '144');
INSERT INTO bbt_object_property VALUES (10, 4, '112');
INSERT INTO bbt_object_property VALUES (10, 5, '144');
INSERT INTO bbt_object_property VALUES (10, 6, '90');
INSERT INTO bbt_object_property VALUES (10, 7, '90');
INSERT INTO bbt_object_property VALUES (19, 2, '830');
INSERT INTO bbt_object_property VALUES (19, 3, '440');
INSERT INTO bbt_object_property VALUES (19, 8, '96');
INSERT INTO bbt_object_property VALUES (10, 11, '99');
INSERT INTO bbt_object_property VALUES (10, 14, '2');
INSERT INTO bbt_object_property VALUES (13, 1, '850');
INSERT INTO bbt_object_property VALUES (13, 2, '2140');
INSERT INTO bbt_object_property VALUES (13, 3, '6200');
INSERT INTO bbt_object_property VALUES (19, 4, '80');
INSERT INTO bbt_object_property VALUES (19, 5, '80');
INSERT INTO bbt_object_property VALUES (19, 6, '90');
INSERT INTO bbt_object_property VALUES (8, 27, '0');
INSERT INTO bbt_object_property VALUES (9, 27, '1');
INSERT INTO bbt_object_property VALUES (10, 27, '1');
INSERT INTO bbt_object_property VALUES (11, 27, '0');
INSERT INTO bbt_object_property VALUES (12, 27, '0');
INSERT INTO bbt_object_property VALUES (21, 43, '391');
INSERT INTO bbt_object_property VALUES (14, 27, '0');
INSERT INTO bbt_object_property VALUES (15, 27, '0');
INSERT INTO bbt_object_property VALUES (16, 27, '0');
INSERT INTO bbt_object_property VALUES (17, 28, '-1');
INSERT INTO bbt_object_property VALUES (17, 29, '-1');
INSERT INTO bbt_object_property VALUES (17, 30, '-1');
INSERT INTO bbt_object_property VALUES (17, 27, '1');
INSERT INTO bbt_object_property VALUES (18, 1, '1235');
INSERT INTO bbt_object_property VALUES (18, 2, '872');
INSERT INTO bbt_object_property VALUES (18, 3, '610');
INSERT INTO bbt_object_property VALUES (18, 4, '120');
INSERT INTO bbt_object_property VALUES (18, 5, '120');
INSERT INTO bbt_object_property VALUES (18, 6, '90');
INSERT INTO bbt_object_property VALUES (18, 7, '90');
INSERT INTO bbt_object_property VALUES (18, 8, '96');
INSERT INTO bbt_object_property VALUES (18, 27, '1');
INSERT INTO bbt_object_property VALUES (14, 25, '1');
INSERT INTO bbt_object_property VALUES (16, 25, '1');
INSERT INTO bbt_object_property VALUES (15, 25, '1');
INSERT INTO bbt_object_property VALUES (14, 1, '87');
INSERT INTO bbt_object_property VALUES (14, 2, '87');
INSERT INTO bbt_object_property VALUES (14, 3, '786');
INSERT INTO bbt_object_property VALUES (14, 26, '44');
INSERT INTO bbt_object_property VALUES (1, 8, '1');
INSERT INTO bbt_object_property VALUES (1, 9, '1');
INSERT INTO bbt_object_property VALUES (1, 10, '1');
INSERT INTO bbt_object_property VALUES (2, 11, '99');
INSERT INTO bbt_object_property VALUES (2, 12, 'Cone');
INSERT INTO bbt_object_property VALUES (2, 13, 'Dome');
INSERT INTO bbt_object_property VALUES (1, 13, 'Flat');
INSERT INTO bbt_object_property VALUES (1, 12, 'Tube');
INSERT INTO bbt_object_property VALUES (10, 13, 'Dome');
INSERT INTO bbt_object_property VALUES (10, 12, 'Cone');
INSERT INTO bbt_object_property VALUES (2, 8, '96');
INSERT INTO bbt_object_property VALUES (2, 6, '90');
INSERT INTO bbt_object_property VALUES (2, 7, '90');
INSERT INTO bbt_object_property VALUES (3, 12, 'Cone');
INSERT INTO bbt_object_property VALUES (3, 13, 'Dome');
INSERT INTO bbt_object_property VALUES (3, 8, '3');
INSERT INTO bbt_object_property VALUES (3, 10, '1');
INSERT INTO bbt_object_property VALUES (3, 4, '150');
INSERT INTO bbt_object_property VALUES (3, 5, '509');
INSERT INTO bbt_object_property VALUES (3, 7, '150');
INSERT INTO bbt_object_property VALUES (4, 11, '99');
INSERT INTO bbt_object_property VALUES (4, 12, 'Cone');
INSERT INTO bbt_object_property VALUES (4, 13, 'Dome');
INSERT INTO bbt_object_property VALUES (4, 8, '96');
INSERT INTO bbt_object_property VALUES (4, 6, '90');
INSERT INTO bbt_object_property VALUES (4, 7, '90');
INSERT INTO bbt_object_property VALUES (11, 25, '1');
INSERT INTO bbt_object_property VALUES (10, 25, '1');
INSERT INTO bbt_object_property VALUES (11, 1, '250');
INSERT INTO bbt_object_property VALUES (11, 2, '250');
INSERT INTO bbt_object_property VALUES (11, 3, '1500');
INSERT INTO bbt_object_property VALUES (11, 26, '125');
INSERT INTO bbt_object_property VALUES (11, 8, '1');
INSERT INTO bbt_object_property VALUES (11, 9, '1');
INSERT INTO bbt_object_property VALUES (12, 25, '1');
INSERT INTO bbt_object_property VALUES (12, 1, '130');
INSERT INTO bbt_object_property VALUES (12, 2, '130');
INSERT INTO bbt_object_property VALUES (12, 3, '405');
INSERT INTO bbt_object_property VALUES (12, 26, '65');
INSERT INTO bbt_object_property VALUES (12, 8, '1');
INSERT INTO bbt_object_property VALUES (12, 9, '1');
INSERT INTO bbt_object_property VALUES (12, 10, '1');
INSERT INTO bbt_object_property VALUES (15, 1, '72');
INSERT INTO bbt_object_property VALUES (15, 2, '72');
INSERT INTO bbt_object_property VALUES (15, 3, '505');
INSERT INTO bbt_object_property VALUES (15, 26, '36');
INSERT INTO bbt_object_property VALUES (16, 1, '60');
INSERT INTO bbt_object_property VALUES (16, 2, '60');
INSERT INTO bbt_object_property VALUES (16, 3, '458');
INSERT INTO bbt_object_property VALUES (19, 7, '90');
INSERT INTO bbt_object_property VALUES (20, 25, '1');
INSERT INTO bbt_object_property VALUES (20, 1, '1190');
INSERT INTO bbt_object_property VALUES (20, 2, '830');
INSERT INTO bbt_object_property VALUES (20, 3, '440');
INSERT INTO bbt_object_property VALUES (20, 8, '96');
INSERT INTO bbt_object_property VALUES (20, 4, '90');
INSERT INTO bbt_object_property VALUES (20, 5, '90');
INSERT INTO bbt_object_property VALUES (13, 27, '0');
INSERT INTO bbt_object_property VALUES (21, 42, '363');
INSERT INTO bbt_object_property VALUES (8, 35, '204');
INSERT INTO bbt_object_property VALUES (8, 38, '254');
INSERT INTO bbt_object_property VALUES (8, 37, '254');
INSERT INTO bbt_object_property VALUES (8, 34, '95');
INSERT INTO bbt_object_property VALUES (8, 1, '14650');
INSERT INTO bbt_object_property VALUES (21, 27, '0');
INSERT INTO bbt_object_property VALUES (8, 41, '39');
INSERT INTO bbt_object_property VALUES (8, 40, '58');
INSERT INTO bbt_object_property VALUES (8, 39, '2262');
INSERT INTO bbt_object_property VALUES (13, 20, '1250');
INSERT INTO bbt_object_property VALUES (13, 21, '500');
INSERT INTO bbt_object_property VALUES (13, 22, '4640');
INSERT INTO bbt_object_property VALUES (14, 55, '100');
INSERT INTO bbt_object_property VALUES (14, 23, '287');
INSERT INTO bbt_object_property VALUES (15, 23, '160');
INSERT INTO bbt_object_property VALUES (16, 23, '43');
INSERT INTO bbt_object_property VALUES (17, 1, '1390');
INSERT INTO bbt_object_property VALUES (17, 2, '895');
INSERT INTO bbt_object_property VALUES (17, 3, '590');
INSERT INTO bbt_object_property VALUES (2, 10, '8');
INSERT INTO bbt_object_property VALUES (3, 9, '3');
INSERT INTO bbt_object_property VALUES (4, 9, '12');
INSERT INTO bbt_object_property VALUES (4, 10, '8');
INSERT INTO bbt_object_property VALUES (10, 9, '12');
INSERT INTO bbt_object_property VALUES (18, 10, '8');
INSERT INTO bbt_object_property VALUES (19, 9, '12');
INSERT INTO bbt_object_property VALUES (19, 10, '8');
INSERT INTO bbt_object_property VALUES (20, 9, '12');
INSERT INTO bbt_object_property VALUES (20, 10, '8');
INSERT INTO bbt_object_property VALUES (22, 1, '14670');
INSERT INTO bbt_object_property VALUES (22, 2, '10000');
INSERT INTO bbt_object_property VALUES (22, 3, '40');
INSERT INTO bbt_object_property VALUES (22, 37, '254');
INSERT INTO bbt_object_property VALUES (22, 38, '254');
INSERT INTO bbt_object_property VALUES (22, 39, '2301');
INSERT INTO bbt_object_property VALUES (22, 40, '59');
INSERT INTO bbt_object_property VALUES (22, 41, '39');
INSERT INTO bbt_object_property VALUES (2, 9, '12');
INSERT INTO bbt_object_property VALUES (22, 34, '69');
INSERT INTO bbt_object_property VALUES (22, 35, '173');
INSERT INTO bbt_object_property VALUES (13, 60, '4650');
INSERT INTO bbt_object_property VALUES (13, 58, '1178');
INSERT INTO bbt_object_property VALUES (13, 59, '519');
INSERT INTO bbt_object_property VALUES (19, 27, '1');
INSERT INTO bbt_object_property VALUES (20, 27, '1');


--
-- Name: bbt_object_types_pk_id_seq; Type: SEQUENCE SET; Schema: deck; Owner: biobot
--

SELECT pg_catalog.setval('bbt_object_types_pk_id_seq', 25, true);


--
-- Name: bbt_properties_pk_id_seq; Type: SEQUENCE SET; Schema: deck; Owner: biobot
--

SELECT pg_catalog.setval('bbt_properties_pk_id_seq', 60, true);


--
-- Name: bbt_property_type_pk_id_seq; Type: SEQUENCE SET; Schema: deck; Owner: biobot
--

SELECT pg_catalog.setval('bbt_property_type_pk_id_seq', 24, true);


SET search_path = protocol, pg_catalog;

--
-- Data for Name: bbt_operation_type; Type: TABLE DATA; Schema: protocol; Owner: biobot
--

INSERT INTO bbt_operation_type VALUES (1, 'Start');
INSERT INTO bbt_operation_type VALUES (2, 'Stop');
INSERT INTO bbt_operation_type VALUES (4, 'Load Tip');
INSERT INTO bbt_operation_type VALUES (5, 'Unload Tip');
INSERT INTO bbt_operation_type VALUES (6, 'Move To X');
INSERT INTO bbt_operation_type VALUES (7, 'Move To Y');
INSERT INTO bbt_operation_type VALUES (8, 'Move To Z');
INSERT INTO bbt_operation_type VALUES (3, 'Move To Object');
INSERT INTO bbt_operation_type VALUES (9, 'Dispense');
INSERT INTO bbt_operation_type VALUES (10, 'Home x');
INSERT INTO bbt_operation_type VALUES (11, 'Home y');
INSERT INTO bbt_operation_type VALUES (13, 'Home z2');
INSERT INTO bbt_operation_type VALUES (14, 'Home z3');
INSERT INTO bbt_operation_type VALUES (12, 'Home tool');


--
-- Data for Name: bbt_protocol; Type: TABLE DATA; Schema: protocol; Owner: biobot
--

INSERT INTO bbt_protocol VALUES (1, NULL, 'EColi', 0);
INSERT INTO bbt_protocol VALUES (30, 1, 'Home all', 1);


--
-- Data for Name: bbt_step; Type: TABLE DATA; Schema: protocol; Owner: biobot
--

INSERT INTO bbt_step VALUES (2, 30, 'Home toolrack', '""', 6, 1);
INSERT INTO bbt_step VALUES (3, 30, 'Home pipette', '""', 7, 2);


--
-- Data for Name: bbt_operation; Type: TABLE DATA; Schema: protocol; Owner: biobot
--

INSERT INTO bbt_operation VALUES (3, 10, 2, 1, '');
INSERT INTO bbt_operation VALUES (2, 11, 2, 2, '');
INSERT INTO bbt_operation VALUES (6, 7, 3, 1, '500');
INSERT INTO bbt_operation VALUES (4, 6, 3, 3, '30');
INSERT INTO bbt_operation VALUES (5, 12, 3, 2, '');
INSERT INTO bbt_operation VALUES (7, 4, 3, 4, '1');


--
-- Name: bbt_operation_pk_id_seq; Type: SEQUENCE SET; Schema: protocol; Owner: biobot
--

SELECT pg_catalog.setval('bbt_operation_pk_id_seq', 7, true);


--
-- Data for Name: bbt_operation_reference; Type: TABLE DATA; Schema: protocol; Owner: biobot
--

INSERT INTO bbt_operation_reference VALUES (2, 2, 26);
INSERT INTO bbt_operation_reference VALUES (4, 7, 33);


--
-- Name: bbt_operation_reference_pk_id_seq; Type: SEQUENCE SET; Schema: protocol; Owner: biobot
--

SELECT pg_catalog.setval('bbt_operation_reference_pk_id_seq', 4, true);


--
-- Data for Name: bbt_operation_reference_property; Type: TABLE DATA; Schema: protocol; Owner: biobot
--



--
-- Data for Name: bbt_operation_type_object_type; Type: TABLE DATA; Schema: protocol; Owner: biobot
--

INSERT INTO bbt_operation_type_object_type VALUES (2, 5, 9);
INSERT INTO bbt_operation_type_object_type VALUES (3, 5, 12);
INSERT INTO bbt_operation_type_object_type VALUES (4, 13, 10);
INSERT INTO bbt_operation_type_object_type VALUES (5, 13, 11);
INSERT INTO bbt_operation_type_object_type VALUES (8, 5, 5);
INSERT INTO bbt_operation_type_object_type VALUES (9, 5, 4);
INSERT INTO bbt_operation_type_object_type VALUES (10, 5, 6);
INSERT INTO bbt_operation_type_object_type VALUES (11, 5, 7);
INSERT INTO bbt_operation_type_object_type VALUES (12, 5, 8);


--
-- Name: bbt_operation_type_object_type_pk_id_seq; Type: SEQUENCE SET; Schema: protocol; Owner: biobot
--

SELECT pg_catalog.setval('bbt_operation_type_object_type_pk_id_seq', 12, true);


--
-- Name: bbt_operation_type_pk_id_seq; Type: SEQUENCE SET; Schema: protocol; Owner: biobot
--

SELECT pg_catalog.setval('bbt_operation_type_pk_id_seq', 14, true);


--
-- Name: bbt_protocol_pk_id_seq; Type: SEQUENCE SET; Schema: protocol; Owner: biobot
--

SELECT pg_catalog.setval('bbt_protocol_pk_id_seq', 30, true);


--
-- Data for Name: bbt_save_protocol; Type: TABLE DATA; Schema: protocol; Owner: biobot
--

INSERT INTO bbt_save_protocol VALUES (0, 'Un-saved');


--
-- Name: bbt_save_protocol_pk_id_seq; Type: SEQUENCE SET; Schema: protocol; Owner: biobot
--

SELECT pg_catalog.setval('bbt_save_protocol_pk_id_seq', 1, true);


--
-- Data for Name: bbt_save_protocol_reference; Type: TABLE DATA; Schema: protocol; Owner: biobot
--



--
-- Name: bbt_save_protocol_reference_pk_id_seq; Type: SEQUENCE SET; Schema: protocol; Owner: biobot
--

SELECT pg_catalog.setval('bbt_save_protocol_reference_pk_id_seq', 1, false);


--
-- Name: bbt_step_pk_id_seq; Type: SEQUENCE SET; Schema: protocol; Owner: biobot
--

SELECT pg_catalog.setval('bbt_step_pk_id_seq', 3, true);


--
-- PostgreSQL database dump complete
--

