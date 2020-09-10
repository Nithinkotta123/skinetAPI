SET IDENTITY_INSERT ProductBrands OFF
SET IDENTITY_INSERT ProductTypes OFF

INSERT INTO ProductBrands (Id,Name)
VALUES (5,'JOHN'); 

delete from ProductBrands where Id=5

SET IDENTITY_INSERT ProductBrands ON
SET IDENTITY_INSERT ProductTypes ON