CREATE TABLE person (
	id uuid NOT NULL,
	"name" varchar(250) NOT NULL,
	birth timestamp NULL,
	salary decimal NULL,
	ispremium bool NOT NULL DEFAULT cast(1 as bool),
	homeaddressid uuid NULL,
	workaddressid uuid NULL,
	creation timestamp NOT NULL,
	createdby varchar(250) NOT NULL,
	lastupdate timestamp,
	lastupdatedby varchar(250)
);

ALTER TABLE person 
ADD CONSTRAINT person_pk 
PRIMARY KEY (id);

CREATE TABLE car (
	id uuid NOT NULL,
	model varchar(500) NOT NULL,
	modelyear int NULL,
	plates varchar(12) NULL,
	creation timestamp NOT NULL,
	createdby varchar(250) NOT NULL,
	lastupdate timestamp,
	lastupdatedby varchar(250)
);

ALTER TABLE car 
ADD CONSTRAINT car_pk 
PRIMARY KEY (id);

CREATE TABLE personcars (
	id uuid NOT NULL,
	personid uuid NOT NULL,
	carid uuid NOT NULL,
	creation timestamp NOT NULL,
	createdby varchar(250) NOT NULL,
	lastupdate timestamp,
	lastupdatedby varchar(250)
);

ALTER TABLE personcars 
ADD CONSTRAINT personcars_pk 
PRIMARY KEY (id);

ALTER TABLE PERSONCARS ADD CONSTRAINT PERSONCARS_PERSONID_FK FOREIGN KEY (PERSONID) REFERENCES PERSON;

ALTER TABLE PERSONCARS ADD CONSTRAINT PERSONCARS_CARID_FK FOREIGN KEY (CARID) REFERENCES CAR;

CREATE TABLE ADDRESS (
	ID UUID NOT NULL,
	LINE1 varchar(250) NOT NULL,
	LINE2 VARCHAR(250),
	ZIPCODE varchar(12),
	INFO varchar(250),
	CREATION TIMESTAMP NOT NULL,
	CREATEDBY VARCHAR(250) NOT NULL,
	LASTUPDATE TIMESTAMP,
	LASTUPDATEDBY VARCHAR(250)
);

ALTER TABLE ADDRESS ADD CONSTRAINT ADDRESS_PK PRIMARY KEY (ID);

ALTER TABLE PERSON ADD CONSTRAINT PERSON_HOMEADDRESSID_FK FOREIGN KEY (HOMEADDRESSID) REFERENCES ADDRESS;

ALTER TABLE PERSON ADD CONSTRAINT PERSON_WORKADDRESSID_FK FOREIGN KEY (WORKADDRESSID) REFERENCES ADDRESS;
