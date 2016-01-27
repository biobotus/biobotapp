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

--
-- Name: deck; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA deck;


ALTER SCHEMA deck OWNER TO postgres;

--
-- Name: protocol; Type: SCHEMA; Schema: -; Owner: biobot
--

CREATE SCHEMA protocol;


ALTER SCHEMA protocol OWNER TO biobot;

SET search_path = deck, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: bbt_information_value; Type: TABLE; Schema: deck; Owner: biobot
--

CREATE TABLE bbt_information_value (
    pk_id integer NOT NULL,
    fk_information_value integer,
    fk_property integer NOT NULL,
    fk_object integer NOT NULL,
    information_value text
);


ALTER TABLE bbt_information_value OWNER TO biobot;

--
-- Name: bbt_information_value_pk_id_seq; Type: SEQUENCE; Schema: deck; Owner: biobot
--

CREATE SEQUENCE bbt_information_value_pk_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE bbt_information_value_pk_id_seq OWNER TO biobot;

--
-- Name: bbt_information_value_pk_id_seq; Type: SEQUENCE OWNED BY; Schema: deck; Owner: biobot
--

ALTER SEQUENCE bbt_information_value_pk_id_seq OWNED BY bbt_information_value.pk_id;


--
-- Name: bbt_object; Type: TABLE; Schema: deck; Owner: biobot
--

CREATE TABLE bbt_object (
    pk_id integer NOT NULL,
    fk_object_type integer,
    deck_x integer,
    deck_y integer,
    rotation integer,
    activated boolean,
    description text,
    fk_object integer,
    deck_z integer
);


ALTER TABLE bbt_object OWNER TO biobot;

--
-- Name: bbt_object_pk_id_seq; Type: SEQUENCE; Schema: deck; Owner: biobot
--

CREATE SEQUENCE bbt_object_pk_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE bbt_object_pk_id_seq OWNER TO biobot;

--
-- Name: bbt_object_pk_id_seq; Type: SEQUENCE OWNED BY; Schema: deck; Owner: biobot
--

ALTER SEQUENCE bbt_object_pk_id_seq OWNED BY bbt_object.pk_id;


--
-- Name: bbt_object_property; Type: TABLE; Schema: deck; Owner: biobot
--

CREATE TABLE bbt_object_property (
    fk_object_type_id integer NOT NULL,
    fk_properties_id integer NOT NULL,
    value text NOT NULL
);


ALTER TABLE bbt_object_property OWNER TO biobot;

--
-- Name: bbt_object_type; Type: TABLE; Schema: deck; Owner: biobot
--

CREATE TABLE bbt_object_type (
    pk_id integer NOT NULL,
    description text
);


ALTER TABLE bbt_object_type OWNER TO biobot;

--
-- Name: bbt_object_types_pk_id_seq; Type: SEQUENCE; Schema: deck; Owner: biobot
--

CREATE SEQUENCE bbt_object_types_pk_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE bbt_object_types_pk_id_seq OWNER TO biobot;

--
-- Name: bbt_object_types_pk_id_seq; Type: SEQUENCE OWNED BY; Schema: deck; Owner: biobot
--

ALTER SEQUENCE bbt_object_types_pk_id_seq OWNED BY bbt_object_type.pk_id;


--
-- Name: bbt_property; Type: TABLE; Schema: deck; Owner: biobot
--

CREATE TABLE bbt_property (
    pk_id integer NOT NULL,
    description text NOT NULL,
    fk_property_type integer DEFAULT 0
);


ALTER TABLE bbt_property OWNER TO biobot;

--
-- Name: bbt_properties_pk_id_seq; Type: SEQUENCE; Schema: deck; Owner: biobot
--

CREATE SEQUENCE bbt_properties_pk_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE bbt_properties_pk_id_seq OWNER TO biobot;

--
-- Name: bbt_properties_pk_id_seq; Type: SEQUENCE OWNED BY; Schema: deck; Owner: biobot
--

ALTER SEQUENCE bbt_properties_pk_id_seq OWNED BY bbt_property.pk_id;


--
-- Name: bbt_property_type; Type: TABLE; Schema: deck; Owner: biobot
--

CREATE TABLE bbt_property_type (
    pk_id integer NOT NULL,
    description text
);


ALTER TABLE bbt_property_type OWNER TO biobot;

--
-- Name: bbt_property_type_pk_id_seq; Type: SEQUENCE; Schema: deck; Owner: biobot
--

CREATE SEQUENCE bbt_property_type_pk_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE bbt_property_type_pk_id_seq OWNER TO biobot;

--
-- Name: bbt_property_type_pk_id_seq; Type: SEQUENCE OWNED BY; Schema: deck; Owner: biobot
--

ALTER SEQUENCE bbt_property_type_pk_id_seq OWNED BY bbt_property_type.pk_id;


SET search_path = protocol, pg_catalog;

--
-- Name: bbt_operation; Type: TABLE; Schema: protocol; Owner: biobot
--

CREATE TABLE bbt_operation (
    pk_id integer NOT NULL,
    fk_operation_type integer NOT NULL,
    fk_step integer NOT NULL,
    index integer,
    value text
);


ALTER TABLE bbt_operation OWNER TO biobot;

--
-- Name: bbt_operation_pk_id_seq; Type: SEQUENCE; Schema: protocol; Owner: biobot
--

CREATE SEQUENCE bbt_operation_pk_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE bbt_operation_pk_id_seq OWNER TO biobot;

--
-- Name: bbt_operation_pk_id_seq; Type: SEQUENCE OWNED BY; Schema: protocol; Owner: biobot
--

ALTER SEQUENCE bbt_operation_pk_id_seq OWNED BY bbt_operation.pk_id;


--
-- Name: bbt_operation_reference; Type: TABLE; Schema: protocol; Owner: biobot
--

CREATE TABLE bbt_operation_reference (
    pk_id integer NOT NULL,
    fk_operation integer NOT NULL,
    fk_object integer NOT NULL
);


ALTER TABLE bbt_operation_reference OWNER TO biobot;

--
-- Name: bbt_operation_reference_pk_id_seq; Type: SEQUENCE; Schema: protocol; Owner: biobot
--

CREATE SEQUENCE bbt_operation_reference_pk_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE bbt_operation_reference_pk_id_seq OWNER TO biobot;

--
-- Name: bbt_operation_reference_pk_id_seq; Type: SEQUENCE OWNED BY; Schema: protocol; Owner: biobot
--

ALTER SEQUENCE bbt_operation_reference_pk_id_seq OWNED BY bbt_operation_reference.pk_id;


--
-- Name: bbt_operation_reference_property; Type: TABLE; Schema: protocol; Owner: biobot
--

CREATE TABLE bbt_operation_reference_property (
    fk_operation_reference_id integer NOT NULL,
    fk_properties_id integer NOT NULL,
    value text NOT NULL
);


ALTER TABLE bbt_operation_reference_property OWNER TO biobot;

--
-- Name: bbt_operation_type; Type: TABLE; Schema: protocol; Owner: biobot
--

CREATE TABLE bbt_operation_type (
    pk_id integer NOT NULL,
    description text NOT NULL
);


ALTER TABLE bbt_operation_type OWNER TO biobot;

--
-- Name: bbt_operation_type_object_type; Type: TABLE; Schema: protocol; Owner: biobot
--

CREATE TABLE bbt_operation_type_object_type (
    pk_id integer NOT NULL,
    fk_object_type integer NOT NULL,
    fk_operation_type integer NOT NULL
);


ALTER TABLE bbt_operation_type_object_type OWNER TO biobot;

--
-- Name: bbt_operation_type_object_type_pk_id_seq; Type: SEQUENCE; Schema: protocol; Owner: biobot
--

CREATE SEQUENCE bbt_operation_type_object_type_pk_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE bbt_operation_type_object_type_pk_id_seq OWNER TO biobot;

--
-- Name: bbt_operation_type_object_type_pk_id_seq; Type: SEQUENCE OWNED BY; Schema: protocol; Owner: biobot
--

ALTER SEQUENCE bbt_operation_type_object_type_pk_id_seq OWNED BY bbt_operation_type_object_type.pk_id;


--
-- Name: bbt_operation_type_pk_id_seq; Type: SEQUENCE; Schema: protocol; Owner: biobot
--

CREATE SEQUENCE bbt_operation_type_pk_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE bbt_operation_type_pk_id_seq OWNER TO biobot;

--
-- Name: bbt_operation_type_pk_id_seq; Type: SEQUENCE OWNED BY; Schema: protocol; Owner: biobot
--

ALTER SEQUENCE bbt_operation_type_pk_id_seq OWNED BY bbt_operation_type.pk_id;


--
-- Name: bbt_protocol; Type: TABLE; Schema: protocol; Owner: biobot
--

CREATE TABLE bbt_protocol (
    pk_id integer NOT NULL,
    fk_protocol integer,
    description text NOT NULL,
    index integer DEFAULT 0
);


ALTER TABLE bbt_protocol OWNER TO biobot;

--
-- Name: bbt_protocol_pk_id_seq; Type: SEQUENCE; Schema: protocol; Owner: biobot
--

CREATE SEQUENCE bbt_protocol_pk_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE bbt_protocol_pk_id_seq OWNER TO biobot;

--
-- Name: bbt_protocol_pk_id_seq; Type: SEQUENCE OWNED BY; Schema: protocol; Owner: biobot
--

ALTER SEQUENCE bbt_protocol_pk_id_seq OWNED BY bbt_protocol.pk_id;


--
-- Name: bbt_save_protocol; Type: TABLE; Schema: protocol; Owner: biobot
--

CREATE TABLE bbt_save_protocol (
    pk_id integer NOT NULL,
    description text NOT NULL
);


ALTER TABLE bbt_save_protocol OWNER TO biobot;

--
-- Name: bbt_save_protocol_pk_id_seq; Type: SEQUENCE; Schema: protocol; Owner: biobot
--

CREATE SEQUENCE bbt_save_protocol_pk_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE bbt_save_protocol_pk_id_seq OWNER TO biobot;

--
-- Name: bbt_save_protocol_pk_id_seq; Type: SEQUENCE OWNED BY; Schema: protocol; Owner: biobot
--

ALTER SEQUENCE bbt_save_protocol_pk_id_seq OWNED BY bbt_save_protocol.pk_id;


--
-- Name: bbt_save_protocol_reference; Type: TABLE; Schema: protocol; Owner: biobot
--

CREATE TABLE bbt_save_protocol_reference (
    pk_id integer NOT NULL,
    fk_save_protocol integer NOT NULL,
    fk_step integer,
    fk_protocol integer,
    index integer
);


ALTER TABLE bbt_save_protocol_reference OWNER TO biobot;

--
-- Name: bbt_save_protocol_reference_pk_id_seq; Type: SEQUENCE; Schema: protocol; Owner: biobot
--

CREATE SEQUENCE bbt_save_protocol_reference_pk_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE bbt_save_protocol_reference_pk_id_seq OWNER TO biobot;

--
-- Name: bbt_save_protocol_reference_pk_id_seq; Type: SEQUENCE OWNED BY; Schema: protocol; Owner: biobot
--

ALTER SEQUENCE bbt_save_protocol_reference_pk_id_seq OWNED BY bbt_save_protocol_reference.pk_id;


--
-- Name: bbt_step; Type: TABLE; Schema: protocol; Owner: biobot
--

CREATE TABLE bbt_step (
    pk_id integer NOT NULL,
    fk_protocol integer,
    description text NOT NULL,
    value text,
    fk_object integer,
    index integer
);


ALTER TABLE bbt_step OWNER TO biobot;

--
-- Name: bbt_step_pk_id_seq; Type: SEQUENCE; Schema: protocol; Owner: biobot
--

CREATE SEQUENCE bbt_step_pk_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE bbt_step_pk_id_seq OWNER TO biobot;

--
-- Name: bbt_step_pk_id_seq; Type: SEQUENCE OWNED BY; Schema: protocol; Owner: biobot
--

ALTER SEQUENCE bbt_step_pk_id_seq OWNED BY bbt_step.pk_id;


SET search_path = deck, pg_catalog;

--
-- Name: pk_id; Type: DEFAULT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_information_value ALTER COLUMN pk_id SET DEFAULT nextval('bbt_information_value_pk_id_seq'::regclass);


--
-- Name: pk_id; Type: DEFAULT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_object ALTER COLUMN pk_id SET DEFAULT nextval('bbt_object_pk_id_seq'::regclass);


--
-- Name: pk_id; Type: DEFAULT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_object_type ALTER COLUMN pk_id SET DEFAULT nextval('bbt_object_types_pk_id_seq'::regclass);


--
-- Name: pk_id; Type: DEFAULT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_property ALTER COLUMN pk_id SET DEFAULT nextval('bbt_properties_pk_id_seq'::regclass);


--
-- Name: pk_id; Type: DEFAULT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_property_type ALTER COLUMN pk_id SET DEFAULT nextval('bbt_property_type_pk_id_seq'::regclass);


SET search_path = protocol, pg_catalog;

--
-- Name: pk_id; Type: DEFAULT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation ALTER COLUMN pk_id SET DEFAULT nextval('bbt_operation_pk_id_seq'::regclass);


--
-- Name: pk_id; Type: DEFAULT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_reference ALTER COLUMN pk_id SET DEFAULT nextval('bbt_operation_reference_pk_id_seq'::regclass);


--
-- Name: pk_id; Type: DEFAULT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_type ALTER COLUMN pk_id SET DEFAULT nextval('bbt_operation_type_pk_id_seq'::regclass);


--
-- Name: pk_id; Type: DEFAULT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_type_object_type ALTER COLUMN pk_id SET DEFAULT nextval('bbt_operation_type_object_type_pk_id_seq'::regclass);


--
-- Name: pk_id; Type: DEFAULT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_protocol ALTER COLUMN pk_id SET DEFAULT nextval('bbt_protocol_pk_id_seq'::regclass);


--
-- Name: pk_id; Type: DEFAULT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_save_protocol ALTER COLUMN pk_id SET DEFAULT nextval('bbt_save_protocol_pk_id_seq'::regclass);


--
-- Name: pk_id; Type: DEFAULT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_save_protocol_reference ALTER COLUMN pk_id SET DEFAULT nextval('bbt_save_protocol_reference_pk_id_seq'::regclass);


--
-- Name: pk_id; Type: DEFAULT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_step ALTER COLUMN pk_id SET DEFAULT nextval('bbt_step_pk_id_seq'::regclass);


SET search_path = deck, pg_catalog;

--
-- Name: bbt_information_value_pkey; Type: CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_information_value
    ADD CONSTRAINT bbt_information_value_pkey PRIMARY KEY (pk_id);


--
-- Name: bbt_object_pkey; Type: CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_object
    ADD CONSTRAINT bbt_object_pkey PRIMARY KEY (pk_id);


--
-- Name: bbt_object_properties_pkey; Type: CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_object_property
    ADD CONSTRAINT bbt_object_properties_pkey PRIMARY KEY (fk_object_type_id, fk_properties_id);


--
-- Name: bbt_object_types_pkey; Type: CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_object_type
    ADD CONSTRAINT bbt_object_types_pkey PRIMARY KEY (pk_id);


--
-- Name: bbt_object_types_ukey; Type: CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_object_type
    ADD CONSTRAINT bbt_object_types_ukey UNIQUE (description);


--
-- Name: bbt_object_ukey; Type: CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_object
    ADD CONSTRAINT bbt_object_ukey UNIQUE (description);


--
-- Name: bbt_properties_pkey; Type: CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_property
    ADD CONSTRAINT bbt_properties_pkey PRIMARY KEY (pk_id);


--
-- Name: bbt_properties_ukey; Type: CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_property
    ADD CONSTRAINT bbt_properties_ukey UNIQUE (description, fk_property_type);


--
-- Name: bbt_property_type_pkey; Type: CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_property_type
    ADD CONSTRAINT bbt_property_type_pkey PRIMARY KEY (pk_id);


--
-- Name: bbt_property_type_ukey; Type: CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_property_type
    ADD CONSTRAINT bbt_property_type_ukey UNIQUE (description);


SET search_path = protocol, pg_catalog;

--
-- Name: bbt_operation_pkey; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation
    ADD CONSTRAINT bbt_operation_pkey PRIMARY KEY (pk_id);


--
-- Name: bbt_operation_reference_pkey; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_reference
    ADD CONSTRAINT bbt_operation_reference_pkey PRIMARY KEY (pk_id);


--
-- Name: bbt_operation_reference_property_pkey; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_reference_property
    ADD CONSTRAINT bbt_operation_reference_property_pkey PRIMARY KEY (fk_operation_reference_id, fk_properties_id);


--
-- Name: bbt_operation_reference_ukey; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_reference
    ADD CONSTRAINT bbt_operation_reference_ukey UNIQUE (fk_operation, fk_object);


--
-- Name: bbt_operation_type_object_type_pkey; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_type_object_type
    ADD CONSTRAINT bbt_operation_type_object_type_pkey PRIMARY KEY (pk_id);


--
-- Name: bbt_operation_type_object_type_ukey; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_type_object_type
    ADD CONSTRAINT bbt_operation_type_object_type_ukey UNIQUE (fk_object_type, fk_operation_type);


--
-- Name: bbt_operation_type_pkey; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_type
    ADD CONSTRAINT bbt_operation_type_pkey PRIMARY KEY (pk_id);


--
-- Name: bbt_operation_type_ukey; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_type
    ADD CONSTRAINT bbt_operation_type_ukey UNIQUE (description);


--
-- Name: bbt_operation_ukey; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation
    ADD CONSTRAINT bbt_operation_ukey UNIQUE (pk_id);


--
-- Name: bbt_protocol_pkey; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_protocol
    ADD CONSTRAINT bbt_protocol_pkey PRIMARY KEY (pk_id);


--
-- Name: bbt_protocol_ukey; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_protocol
    ADD CONSTRAINT bbt_protocol_ukey UNIQUE (description);


--
-- Name: bbt_save_protocol_pkey; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_save_protocol
    ADD CONSTRAINT bbt_save_protocol_pkey PRIMARY KEY (pk_id);


--
-- Name: bbt_save_protocol_pkey_ukey; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_save_protocol
    ADD CONSTRAINT bbt_save_protocol_pkey_ukey UNIQUE (description);


--
-- Name: bbt_save_protocol_reference_pkey; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_save_protocol_reference
    ADD CONSTRAINT bbt_save_protocol_reference_pkey PRIMARY KEY (pk_id);


--
-- Name: bbt_step_fk_protocol_index_key; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_step
    ADD CONSTRAINT bbt_step_fk_protocol_index_key UNIQUE (pk_id, fk_protocol, index);


--
-- Name: bbt_step_pkey; Type: CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_step
    ADD CONSTRAINT bbt_step_pkey PRIMARY KEY (pk_id);


SET search_path = deck, pg_catalog;

--
-- Name: fki_bbt_property_property_type_fkey; Type: INDEX; Schema: deck; Owner: biobot
--

CREATE INDEX fki_bbt_property_property_type_fkey ON bbt_property USING btree (fk_property_type);


--
-- Name: fki_object_object_fkey; Type: INDEX; Schema: deck; Owner: biobot
--

CREATE INDEX fki_object_object_fkey ON bbt_object USING btree (fk_object);


SET search_path = protocol, pg_catalog;

--
-- Name: fki_bbt_step_object_fkey; Type: INDEX; Schema: protocol; Owner: biobot
--

CREATE INDEX fki_bbt_step_object_fkey ON bbt_step USING btree (fk_object);


SET search_path = deck, pg_catalog;

--
-- Name: bbt_information_value_info_value_fkey; Type: FK CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_information_value
    ADD CONSTRAINT bbt_information_value_info_value_fkey FOREIGN KEY (fk_information_value) REFERENCES bbt_information_value(pk_id);


--
-- Name: bbt_information_value_object_fkey; Type: FK CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_information_value
    ADD CONSTRAINT bbt_information_value_object_fkey FOREIGN KEY (fk_object) REFERENCES bbt_object(pk_id);


--
-- Name: bbt_information_value_property_fkey; Type: FK CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_information_value
    ADD CONSTRAINT bbt_information_value_property_fkey FOREIGN KEY (fk_property) REFERENCES bbt_property(pk_id);


--
-- Name: bbt_object_object_type_fkey; Type: FK CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_object
    ADD CONSTRAINT bbt_object_object_type_fkey FOREIGN KEY (fk_object_type) REFERENCES bbt_object_type(pk_id);


--
-- Name: bbt_object_properties_object_type_fkey; Type: FK CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_object_property
    ADD CONSTRAINT bbt_object_properties_object_type_fkey FOREIGN KEY (fk_object_type_id) REFERENCES bbt_object_type(pk_id);


--
-- Name: bbt_object_properties_properties_fkey; Type: FK CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_object_property
    ADD CONSTRAINT bbt_object_properties_properties_fkey FOREIGN KEY (fk_properties_id) REFERENCES bbt_property(pk_id);


--
-- Name: bbt_property_property_type_fkey; Type: FK CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_property
    ADD CONSTRAINT bbt_property_property_type_fkey FOREIGN KEY (fk_property_type) REFERENCES bbt_property_type(pk_id);


--
-- Name: fk_object_object_fkey; Type: FK CONSTRAINT; Schema: deck; Owner: biobot
--

ALTER TABLE ONLY bbt_object
    ADD CONSTRAINT fk_object_object_fkey FOREIGN KEY (fk_object) REFERENCES bbt_object(pk_id);


SET search_path = protocol, pg_catalog;

--
-- Name: bbt_information_value_information_fkey; Type: FK CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_protocol
    ADD CONSTRAINT bbt_information_value_information_fkey FOREIGN KEY (fk_protocol) REFERENCES bbt_protocol(pk_id);


--
-- Name: bbt_object_properties_properties_fkey; Type: FK CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_reference_property
    ADD CONSTRAINT bbt_object_properties_properties_fkey FOREIGN KEY (fk_properties_id) REFERENCES deck.bbt_property(pk_id);


--
-- Name: bbt_operation_operation_type_fkey; Type: FK CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation
    ADD CONSTRAINT bbt_operation_operation_type_fkey FOREIGN KEY (fk_operation_type) REFERENCES bbt_operation_type(pk_id);


--
-- Name: bbt_operation_reference_operation_fkey; Type: FK CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_reference
    ADD CONSTRAINT bbt_operation_reference_operation_fkey FOREIGN KEY (fk_operation) REFERENCES bbt_operation(pk_id);


--
-- Name: bbt_operation_reference_property_op_ref_fkey; Type: FK CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_reference_property
    ADD CONSTRAINT bbt_operation_reference_property_op_ref_fkey FOREIGN KEY (fk_operation_reference_id) REFERENCES bbt_operation_reference(pk_id);


--
-- Name: bbt_operation_reference_step_fkep; Type: FK CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_reference
    ADD CONSTRAINT bbt_operation_reference_step_fkep FOREIGN KEY (fk_object) REFERENCES deck.bbt_object(pk_id);


--
-- Name: bbt_operation_step_fkey; Type: FK CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation
    ADD CONSTRAINT bbt_operation_step_fkey FOREIGN KEY (fk_step) REFERENCES bbt_step(pk_id);


--
-- Name: bbt_operation_type_object_type_object_type_fkey; Type: FK CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_type_object_type
    ADD CONSTRAINT bbt_operation_type_object_type_object_type_fkey FOREIGN KEY (fk_object_type) REFERENCES deck.bbt_object_type(pk_id);


--
-- Name: bbt_operation_type_object_type_operation_type_fkey; Type: FK CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_operation_type_object_type
    ADD CONSTRAINT bbt_operation_type_object_type_operation_type_fkey FOREIGN KEY (fk_operation_type) REFERENCES bbt_operation_type(pk_id);


--
-- Name: bbt_save_protocol_reference_protocol_fkey; Type: FK CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_save_protocol_reference
    ADD CONSTRAINT bbt_save_protocol_reference_protocol_fkey FOREIGN KEY (fk_protocol) REFERENCES bbt_protocol(pk_id);


--
-- Name: bbt_save_protocol_reference_step_fkey; Type: FK CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_save_protocol_reference
    ADD CONSTRAINT bbt_save_protocol_reference_step_fkey FOREIGN KEY (fk_step) REFERENCES bbt_step(pk_id);


--
-- Name: bbt_step_object_fkey; Type: FK CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_step
    ADD CONSTRAINT bbt_step_object_fkey FOREIGN KEY (fk_object) REFERENCES deck.bbt_object(pk_id);


--
-- Name: bbt_step_protocol_fkey; Type: FK CONSTRAINT; Schema: protocol; Owner: biobot
--

ALTER TABLE ONLY bbt_step
    ADD CONSTRAINT bbt_step_protocol_fkey FOREIGN KEY (fk_protocol) REFERENCES bbt_protocol(pk_id);


--
-- Name: deck; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA deck FROM PUBLIC;
REVOKE ALL ON SCHEMA deck FROM postgres;
GRANT ALL ON SCHEMA deck TO postgres;
GRANT ALL ON SCHEMA deck TO biobot;


SET search_path = deck, pg_catalog;

--
-- Name: bbt_object; Type: ACL; Schema: deck; Owner: biobot
--

REVOKE ALL ON TABLE bbt_object FROM PUBLIC;
REVOKE ALL ON TABLE bbt_object FROM biobot;
GRANT ALL ON TABLE bbt_object TO biobot;


--
-- PostgreSQL database dump complete
--

