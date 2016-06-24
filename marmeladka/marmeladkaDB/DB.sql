USE marmeladkaDB;
GO

CREATE TABLE category(
id uniqueidentifier NOT NULL PRIMARY KEY,
name nvarchar(100) NOT NULL,
isDelete bit
);

CREATE TABLE company(
id uniqueidentifier NOT NULL PRIMARY KEY,
name nvarchar(100) NOT NULL,
isDelete bit
);

CREATE TABLE product(
id uniqueidentifier NOT NULL PRIMARY KEY,
name nvarchar(100),
Recomended bit NOT NULL,
opt_price decimal NOT NULL,
retail_price decimal NOT NULL,
categoryId uniqueidentifier NOT NULL,
CONSTRAINT fk_product_category FOREIGN KEY (categoryID) REFERENCES category(Id),
companyId uniqueidentifier NOT NULL,
CONSTRAINT fk_product_company FOREIGN KEY (companyId) REFERENCES company(id),
product_weight int NOT NULL
);

CREATE TABLE [user](
id uniqueidentifier NOT NULL PRIMARY KEY,
name nvarchar(100) NOT NULL,
second_name nvarchar(100) NOT NULL,
adress nvarchar(100) NOT NULL,
email nvarchar(100) NOT NULL,
postcode nvarchar(50) NOT NULL
phone nvarchar(50)
);

CREATE TABLE [order](
id uniqueidentifier NOT NULL PRIMARY KEY,
order_time datetime NOT NULL,
userId uniqueidentifier NOT NULL,
[order-price] decimal,
OrderWeight int,
CONSTRAINT fk_orders_user FOREIGN KEY (userId) REFERENCES [user](id)
);

CREATE TABLE action_order(
id uniqueidentifier NOT NULL PRIMARY KEY,
productId uniqueidentifier NOT NULL,
CurrentProductWeight int,
CONSTRAINT fk_action_products FOREIGN KEY (productId) REFERENCES product(id),
ordersId uniqueidentifier NOT NULL,
CONSTRAINT fk_action_orders FOREIGN KEY (ordersId) REFERENCES [order](Id)
);

CREATE TABLE [Admin](
Id uniqueidentifier NOT NULL PRIMARY KEY,
Name nvarchar(50) UNIQUE NOT NULL,
Salt nvarchar(50) NOT NULL,
[Password] nvarchar(50) NOT NULL,
CaBeDeleted bit NOT NULL
);

alter table action_order
add constraint order_constraint UNIQUE(productId,ordersId)