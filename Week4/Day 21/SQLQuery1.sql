CREATE DATABASE DEMO;

USE DEMO;

CREATE TABLE Product(
maker char(1),
model char(4),
type varchar(7));


CREATE TABLE Printer(
code int,
model char(4),
price decimal(6,2)
);

INSERT INTO Product (maker, model, type)
VALUES ('A','Oreo','cookie');

INSERT INTO Printer (code, model, price)
VALUES (3,'ROX',300.99);

ALTER TABLE Printer
ADD type varchar(6) CHECK (type in ('laser', 'matrix' , 'jet'));

ALTER TABLE Printer
ADD color char(1) CHECK (color in ('y', 'n'));

ALTER TABLE Printer
DROP COLUMN price;

DROP TABLE Product;

DROP TABLE Printer;