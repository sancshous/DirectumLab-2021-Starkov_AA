use Block2;

insert into dbo.Sellers (LastName, FirstName, ThirdName, City, CommissionPercent)
values
('Petrov', 'Petr', 'Petrovich', 'Moscow', 10),
('Mamedov', 'Alexey', 'Sergeevich', 'Izhevsk', 8),
('Antonov', 'Anton', 'Antonovich', 'Piter', 5)

insert into dbo.Customers (LastName, FirstName, ThirdName, City)
values
('Starkov', 'Alexandr', 'Andreevich', 'Piter'),
('Ivanov', 'Ivan', 'Alekseevich', 'Izhevsk'),
('Vasina', 'Maria', 'Petrovna', 'Moscow'),
('Lvov', 'Lev', 'Lvovich', 'Izhevsk'),
('Petrov', 'Petr', 'Petrovich', 'Moscow')

insert into dbo.Orders (Summary, Amount, OrderDateTime, CustomerId, SellerId)
values
('Summary#1', 2000, '2021-01-01T12:00:00', 1, 1),
('Summary#2', 1000, '2021-01-22T12:00:00', 3, 3),
('Summary#3', 30000, '2021-03-01T12:00:00', 4, 2),
('Summary#4', 500, '2021-10-01T12:00:00', 5, 3),
('Summary#5', 12500, '2021-10-02T12:00:00', 1, 3),
('Summary#6', 3500, '2021-10-02T12:00:00', 1, 2),
('Summary#7', 32500, '2021-10-02T12:00:00', 1, 2),
('Summary#8', 1000, '2021-10-02T12:00:00', 2, 3),
('Summary#9', 10000, '2021-10-02T12:00:00', 2, 2),
('Summary#10', 11100, '2021-10-02T12:00:00', 3, 3),
('Summary#11', 11100, '2021-10-02T12:00:00', 3, 1)
