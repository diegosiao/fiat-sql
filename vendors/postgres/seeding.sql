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

ALTER TABLE personcars
ADD CONSTRAINT personcars_personid_fk
FOREIGN KEY (personid) 
REFERENCES person; 

ALTER TABLE personcars
ADD CONSTRAINT personcars_carid_fk
FOREIGN KEY (carid) 
REFERENCES car; 
