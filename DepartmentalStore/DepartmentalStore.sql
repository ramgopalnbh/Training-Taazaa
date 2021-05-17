-- Database: DepartmentalStore

-- DROP DATABASE "DepartmentalStore";

CREATE DATABASE "DepartmentalStore"
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_United States.1252'
    LC_CTYPE = 'English_United States.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;
	
	
--Creating Staff table

CREATE TABLE Staff(
StaffId SERIAL PRIMARY KEY,
StaffName VARCHAR(30),
StaffGender CHAR(1),
StaffPhoneNo INT,
StaffAge INT,
StaffDept VARCHAR(30),
DeptId INT REFERENCES Department (DeptId)
);

--Table of Department
CREATE TABLE Department(
DeptId INT PRIMARY KEY,
DeptName VARCHAR(30)
);  


--Table of Product
CREATE TABLE Product(
ProductId INT PRIMARY KEY,
ProductName VARCHAR(30),
ManufacturerName VARCHAR(30) NOT NULL,
ShortCode CHAR(3) NOT NULL,
SellingPrice INT,
CostPrice INT
);
select * from Product;


--Table of Category
CREATE TABLE Category(
CategoryId INT,
CategoryName VARCHAR(30) NOT NULL,
ProductId INT REFERENCES Product(ProductId) NOT NULL
);


--Table of Inventory
CREATE TABLE Inventory(
InventoryId INT PRIMARY KEY,
ProductId INT REFERENCES Product(ProductId) NOT NULL,
InStock BOOLEAN NOT NULL,
ProductQty INT
);


--Table of PurchaseOrder
CREATE TABLE PurchaseOrder(
OrderId INT PRIMARY KEY,
ProductId INT REFERENCES Product(ProductId)  NOT NULL,
QtyNeeded INT
);

--Table of Supplier
CREATE TABLE Supplier(
ProductId INT REFERENCES Product(ProductId),
SupplierId INT PRIMARY KEY,
SupplierName VARCHAR(128),
OrderDate DATE,
SupplierPhoneNo INT,
SupplierEmail VARCHAR(128),
SupplierCity VARCHAR(30),
SupplierState VARCHAR(30),
OrderId INT REFERENCES PurchaseOrder(OrderId)	
);


--Table of SupplierProduct
CREATE TABLE SupplierProduct(
ProductId INT REFERENCES Product(ProductId) NOT NULL,
SupplierId INT REFERENCES Supplier(SupplierId) NOT NULL
);

select * from Supplier;

select * from Product;


--Data insert into Staff
INSERT INTO Staff (StaffName, StaffGender,StaffPhoneNo, StaffAge, StaffDept) VALUES ('Mohan','M','87235762',12 , 'Collector'),
('Mohit','M','927826677',22,'Searcher'),('prem','F','95365287',12,'Stocker'),('Ravi','M','72862887',23,'Stocker');

select * from Staff;

--1. Query of Staff using Name
SELECT * FROM Staff WHERE StaffName = 'prem';
   
--1.Query staff using Phone no   
SELECT * FROM Staff WHERE StaffPhoneNo = '927826677';
   
-- 2. Query Staff using their role
SELECT StaffName from Staff WHERE StaffDept = 'Stocker';


--Data insert into Product
INSERT INTO Product(ProductId,ManufacturerName,ShortCode,SellingPrice,CostPrice,ProductName) VALUES (12,'Okia','ONO',2500,4000,'TV'),
    (13, 'Wirlpool','fz',15000,18000,'TV'),
    (14,'Samsung','ac',300000,40000,'Chair'),
    (15,'Oppo','mob',16999,19999,'Mobile'),
    (16,'Microsoft','lap',45000,55000,'Surface');
   
INSERT INTO product(ProductId,ManufacturerName,ShortCode,SellingPrice,CostPrice,ProductName)
    VALUES(11, 'sunfeest', 'mg',50,60,'Maggie'),
    (91,'cadbaury', 'dm',100,120,'Dairy Curd'),
    (19, 'ParleG','coo',200,300,'Cookies'),
    (20,'Parag','mlk',50,80,'Milk'),
    (21,'MotherDairy','crm',500,700,'Cream');
	
	
--data insert into Inventory
INSERT INTO Inventory(InventoryId,ProductId,InStock,ProductQty)
    VALUES(1,11,true,10),
    (2,19,false,0),
    (3,20,true,5),
    (4,21,true,6),
    (5,16,false,0);
	
	
--data insert into Category
INSERT INTO Category(CategoryId,CategoryName,ProductId)
    VALUES(1,'Electronics',13),
    (2,'Electronics',14),
    (3,'Electronics',15),
    (4,'Electronics',16),
    (5,'Electronics',12),
    (6,'Food',11),
    (7,'Chocolates',91),
    (8,'Food',19),
    (9,'Dairy',20),
    (10,'Dairy',21)
    
    
SELECT * from Inventory;

-- Query product  based on Name
SELECT * FROM Product
WHERE ProductName='TV';
   
--Based on Category
SELECT * FROM Product INNER JOIN  Category
    ON Product.ProductId=CategoryId 
    where Category.CategoryName='Electronics';
    
--Based on instock,outstock
SELECT * from Product INNER JOIN Inventory
   on Product.ProductId = Inventory.ProductId
   where InStock = true;
   
   
--SellingPrice less than
SELECT ProductName, SellingPrice FROM Product WHERE SellingPrice < 800;
   
--SellingPrice greater than 
SELECT ProductName, SellingPrice FROM Product WHERE SellingPrice > 1500;

--SellingPrice between
SELECT ProductName, SellingPrice FROM Product WHERE SellingPrice BETWEEN 10000 AND 12000;

 
--4- Numbers of Products out of stock
SELECT COUNT(Inventory.ProductId)
   from Product INNER JOIN Inventory
   on Product.ProductId = Inventory.ProductId
   where InStock = false;
   
--5- Number of Products within a Categpory
SELECT COUNT(Product.ProductId)
    FROM Product INNER JOIN  Category
    ON Product.ProductId=Category.CategoryId 
    where CategoryName='Dairy';
    
    
--6- Hghest to lowest
SELECT Category.CategoryName,COUNT(DISTINCT(Product.ProductName))
    FROM Product INNER JOIN Category
    ON Product.ProductId=Category.CategoryId 
    GROUP BY Category.CategoryName
    ORDER BY COUNT(DISTINCT(Product.ProductName)) DESC;
    

--insert data into supplier table
INSERT INTO Supplier(ProductId,SupplierId,SupplierName,OrderDate,SupplierPhoneNo,SupplierEmail,SupplierCity,SupplierState,OrderId)
    VALUES(11,1,'Mohan','2000-12-30','1111232333','mohan@gmail.com','Ghaziabad','UP',1),
    (12,2,'Sunil','1888-12-30','22222232','sunil@gmail.com','Patna','Bihar',2),
    (13,3,'Amit','1999-10-21','98923823','amit@gmail.com','fzd','UP',3),
    (14,4,'Abhishek','2000-1-13','22222432','abhishek@gmail.com','Agra','UP',4),
    (15,5,'Yanshik','1666-12-20','98232323','yanshik@gmail.com','Bijnor','UP',5);

    

--data insert into PerchaseOrder table
INSERT INTO PurchaseOrder(OrderId,ProductId,QtyNeeded)
     VALUES(1,11,5),
     (2,12,10),
     (3,13,10),
     (4,14,20),
     (5,15,2);
	 
select * from PurchaseOrder;



--7a. List of supplier NAme;
SELECT SupplierName FROM Supplier;
SELECT * FROM Supplier WHERE SupplierName ='Mohan';
	
	
--7b. List of supplier Phone;
SELECT SupplierPhoneNo FROM Supplier;
   
--7c. List of supplier Email;
SELECT SupplierEmail FROM Supplier;
   
--7d. List of supplier City;
SELECT SupplierCity FROM Supplier;
		
SELECT SupplierState FROM Supplier;
	
INSERT INTO SupplierProduct(ProductId,SupplierId)
    VALUES(11,1),
    (12,1),
    (13,2),
    (14,3),
    (14,4),
    (19,1);
   
--8th Query
SELECT Product.ProductName,Supplier.SupplierName,Supplier.OrderDate,PurchaseOrder.QtyNeeded FROM Product
    INNER JOIN Supplier
    ON Product.ProductId= Supplier.ProductId INNER JOIN SupplierProduct
    ON Product.ProductId = SupplierProduct.ProductId INNER JOIN PurchaseOrder ON Product.ProductId = PurchaseOrder.ProductId;
     
select * from supplierproduct;

--8a Product name 
SELECT Product.ProductName,Supplier.SupplierName,Supplier.OrderDate,PurchaseOrder.QtyNeeded FROM Product
    INNER JOIN Supplier
    ON Product.ProductId= Supplier.ProductId INNER JOIN SupplierProduct
    ON Product.ProductId = SupplierProduct.ProductId INNER JOIN PurchaseOrder ON Product.ProductId = PurchaseOrder.ProductId
    WHERE Product.ProductName = 'TV';

--8b Using Supplier Name  
SELECT Product.ProductName,Supplier.SupplierName,Supplier.OrderDate,PurchaseOrder.QtyNeeded FROM Product
    INNER JOIN Supplier
    ON Product.ProductId= Supplier.ProductId INNER JOIN SupplierProduct
    ON Product.ProductId =SupplierProduct.ProductId INNER JOIN PurchaseOrder ON Product.ProductId = PurchaseOrder.ProductId
    WHERE Supplier.SupplierName ='Mohan';
   
--8c Using Product Code
SELECT Product.ProductName,Supplier.SupplierName,Supplier.OrderDate,PurchaseOrder.QtyNeeded FROM Product
    INNER JOIN Supplier
    ON Product.ProductId= Supplier.ProductId INNER JOIN SupplierProduct
    ON Product.ProductId =SupplierProduct.ProductId INNER JOIN PurchaseOrder ON Product.ProductId = PurchaseOrder.ProductId
    WHERE Product.ShortCode = 'fz';
   
--8d Supplied After a particular date
SELECT Product.ProductName,Supplier.SupplierName,Supplier.OrderDate,PurchaseOrder.QtyNeeded FROM Product
    INNER JOIN Supplier
    ON Product.ProductId= Supplier.ProductId INNER JOIN SupplierProduct
    ON Product.ProductId =SupplierProduct.ProductId INNER JOIN PurchaseOrder ON Product.ProductId = PurchaseOrder.ProductId
    WHERE Supplier.OrderDate > '1990-12-25';
   
--8e Supplied Before a particular date  
SELECT Product.ProductName,Supplier.SupplierName,Supplier.OrderDate,PurchaseOrder.QtyNeeded FROM Product
    INNER JOIN Supplier
    ON Product.ProductId= Supplier.ProductId INNER JOIN SupplierProduct
    ON Product.ProductId =SupplierProduct.ProductId INNER JOIN PurchaseOrder ON Product.ProductId = PurchaseOrder.ProductId
    WHERE Supplier.OrderDate < '1990-12-25';
    
--less than
SELECT Product.ProductName,Supplier.SupplierName,Supplier.OrderDate,PurchaseOrder.QtyNeeded FROM Product
    INNER JOIN Supplier
    ON Product.ProductId= Supplier.ProductId INNER JOIN SupplierProduct
    ON Product.ProductId =SupplierProduct.ProductId INNER JOIN PurchaseOrder ON Product.ProductId = PurchaseOrder.ProductId
    WHERE PurchaseOrder.QtyNeeded < 6;

--More than
SELECT Product.ProductName,Supplier.SupplierName,Supplier.OrderDate,PurchaseOrder.QtyNeeded FROM Product
    INNER JOIN Supplier
    ON Product.ProductId= Supplier.ProductId INNER JOIN SupplierProduct
    ON Product.ProductId = SupplierProduct.ProductId INNER JOIN PurchaseOrder ON Product.ProductId = PurchaseOrder.ProductId
    WHERE PurchaseOrder.QtyNeeded > 6;