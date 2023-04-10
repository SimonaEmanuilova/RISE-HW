CREATE DATABASE Flights;

USE Flights;

CREATE TABLE AIRLINE(
CODE char(2) Primary Key,
NAME varchar(50) UNIQUE NOT NULL,
COUNTRY varchar(60) NOT NULL
);

CREATE TABLE AIRPORT(
CODE char(3) Primary Key,
NAME varchar(70) NOT NULL,
COUNTRY varchar(60) NOT NULL,
CITY varchar(40) NOT NULL,
CONSTRAINT uq_ap UNIQUE(NAME,COUNTRY)
);

CREATE TABLE AIRPLANE(
CODE char(3) Primary Key,
TYPE varchar(30) NOT NULL,
SEATS int CHECK (SEATS >= 1) NOT NULL,
YEAR int NOT NULL
);

CREATE TABLE FLIGHT(
FNUMBER varchar(10) Primary Key,
AIRLINE_OPERATOR char(2) NOT NULL,
DEP_AIRPORT char(3) NOT NULL,
ARR_AIRPORT char(3) NOT NULL,
FLIGHT_TIME TIME NOT NULL,
FLIGHT_DURATION int NOT NULL ,
AIRPLANE char(3) NOT NULL
);

CREATE TABLE CUSTOMER(
ID int Primary Key,
FNAME varchar(30) NOT NULL,
LNAME varchar(30) NOT NULL,
EMAIL varchar(70) NOT NULL CHECK (EMAIL LIKE '_%@_%._%' AND LEN(EMAIL)>=6 )
);


CREATE TABLE AGENCY(
NAME varchar(50) Primary Key,
COUNTRY varchar(60) NOT NULL,
CITY varchar(40) NOT NULL,
PHONE varchar(20) NULL
);

CREATE TABLE BOOKING(
CODE varchar(10) Primary Key,
AGENCY varchar(50) NOT NULL,
AIRLINE_CODE varchar(2) NOT NULL,
FLIGHT_NUMBER varchar(10) NOT NULL,
CUSTOMER_ID int NOT NULL,
BOOKING_DATE datetime2 NOT NULL,
FLIGHT_DATE datetime2 NOT NULL,
PRICE int NOT NULL,
STATUS int NOT NULL CHECK (STATUS in (0 , 1)) ,
CONSTRAINT ch_date CHECK (FLIGHT_DATE >= BOOKING_DATE)
);


-- TESTS:

--check email:

  --passes with correct email:
INSERT INTO CUSTOMER
VALUES
  (99, 'Pettar', 'Millenov', 'petter@mail.com');

  --fails:
INSERT INTO CUSTOMER
VALUES
  (1, 'Petar', 'Milenov', 'pettermail.com');

INSERT INTO CUSTOMER
VALUES
  (1, 'Petar', 'Milenov', 'petter@mailcom');

INSERT INTO CUSTOMER
VALUES
  (1, 'Petar', 'Milenov', 'pe@m.');


--check status:

--passes:
  INSERT INTO BOOKING
VALUES
  ('Yx398P', 'Travel One', 'FB', 'FB1363', 1, '2013-11-18', '2013-12-25', 300, 0);

    INSERT INTO BOOKING
VALUES
  ('Yx368P', 'Travel One', 'FB', 'FB1363', 1, '2013-11-18', '2013-12-25', 300, 1);

  --fails:
      INSERT INTO BOOKING
VALUES
  ('Y4398P', 'Travel One', 'FB', 'FB1363', 1, '2013-11-18', '2013-12-25', 300, 6);


--check the uq_ap constraint:

  --passes:
  INSERT INTO AIRPORT
VALUES
  ('SOF', 'Sofia International', 'Bulgaria', 'Sofia'),
  ('FSO', 'Sofia International', 'France', 'Paris');

  --fails:
    INSERT INTO AIRPORT
VALUES
  ('DOF', 'Sofia International', 'Bulgaria', 'Sofia'),
  ('OTO', 'Sofia International', 'Bulgaria', 'Paris');
