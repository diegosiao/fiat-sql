CREATE TABLE person (
	id binary(16) NOT NULL,
	name varchar(250) NOT NULL,
	birth date NULL,
	salary decimal NULL,
	ispremium bit NOT NULL DEFAULT 0,
	creation date NOT NULL,
	createdby varchar(250) NOT NULL,
	lastupdate date,
	lastupdatedby varchar(250)
);


ALTER TABLE person 
ADD CONSTRAINT person_pk 
PRIMARY KEY (id);

CREATE TABLE car (
	id binary(16) NOT NULL,
	model varchar(500) NOT NULL,
	modelyear int NULL,
	plates varchar(12) NULL,
	creation date NOT NULL,
	createdby varchar(250) NOT NULL,
	lastupdate date,
	lastupdatedby varchar(250)
);

ALTER TABLE car 
ADD CONSTRAINT car_pk 
PRIMARY KEY (id);

CREATE TABLE personcars (
	id binary(16) NOT NULL,
	personid binary(16) NOT NULL,
	carid binary(16) NOT NULL,
	creation date NOT NULL,
	createdby varchar(250) NOT NULL,
	lastupdate date,
	lastupdatedby varchar(250)
);

ALTER TABLE personcars 
ADD CONSTRAINT personcars_pk 
PRIMARY KEY (id);

ALTER TABLE personcars
ADD CONSTRAINT personcars_personid_fk
FOREIGN KEY (personid) 
REFERENCES person(id); 

ALTER TABLE personcars
ADD CONSTRAINT personcars_carid_fk
FOREIGN KEY (carid) 
REFERENCES car(id); 
