CREATE PROC sp_Orders_add

	@ORDID INT ,
    @NumberOfProdacts int,
    @ProdactsNames varchar(255),
    @ORDAmount varchar(255),
    @ORDDastenyAddress VARCHAR (255),
    @TotalCost int,
    @USRIID int,
    @USRPaymentDDeatals  VARCHAR (255)
AS
begin
	insert into Orders values(
	@ORDID ,
    @NumberOfProdacts ,
    @ProdactsNames ,
    @ORDAmount ,
    @ORDDastenyAddress ,
    @TotalCost ,
    @USRIID  ,
    @USRPaymentDDeatals  
	)
end