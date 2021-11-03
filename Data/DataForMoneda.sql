SET IDENTITY_INSERT [dbo].[Moneda] ON
INSERT INTO [dbo].[Moneda] ([MonedaId], [Nombre], [CantidadCompra], [CantidadVenta]) VALUES (3, N'Albacoin', 300, 200)
INSERT INTO [dbo].[Moneda] ([MonedaId], [Nombre], [CantidadCompra], [CantidadVenta]) VALUES (4, N'Digicrypto', 10000, 5000)
INSERT INTO [dbo].[Moneda] ([MonedaId], [Nombre], [CantidadCompra], [CantidadVenta]) VALUES (5, N'Perocoin', 600 ,400 )
INSERT INTO [dbo].[Moneda] ([MonedaId], [Nombre], [CantidadCompra], [CantidadVenta]) VALUES (6, N'MiCoin', 800 , 700)
SET IDENTITY_INSERT [dbo].[Moneda] OFF
SET IDENTITY_INSERT [dbo].[Conversion] ON
INSERT INTO [dbo].[Conversion] ([ConversionId], [FechaConversion], [ClienteId]) VALUES (8, N'2021-11-13 23:22:22', 23)
SET IDENTITY_INSERT [dbo].[Conversion] OFF