-- Table: deck.bbt_object

-- DROP TABLE deck.bbt_object;

CREATE TABLE deck.bbt_object
(
  pk_id serial NOT NULL,
  fk_object_type integer,
  deck_x integer,
  deck_y integer,
  rotation integer,
  activated boolean,
  description text,
  fk_object integer,
  CONSTRAINT bbt_object_pkey PRIMARY KEY (pk_id),
  CONSTRAINT bbt_object_object_type_fkey FOREIGN KEY (fk_object_type)
      REFERENCES deck.bbt_object_type (pk_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT fk_object_object_fkey FOREIGN KEY (fk_object)
      REFERENCES deck.bbt_object (pk_id) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT bbt_object_ukey UNIQUE (description)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE deck.bbt_object
  OWNER TO biobot;
GRANT ALL ON TABLE deck.bbt_object TO biobot;

-- Index: deck.fki_object_object_fkey

-- DROP INDEX deck.fki_object_object_fkey;

CREATE INDEX fki_object_object_fkey
  ON deck.bbt_object
  USING btree
  (fk_object);

