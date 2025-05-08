use bddprodserv

CREATE TABLE Pagos (
    Id int identity PRIMARY KEY,
    ClienteId VARCHAR(25) NOT NULL,
    Monto MONEY NOT NULL,
    MetodoPago VARCHAR(50),
    FechaPago DATETIME2 NOT NULL,
    Estado VARCHAR(20)
);

select * from Pagos

delete from Pagos

select * from sys.sysprocesses
where spid >= 50 and loginame = 'warlospp'      