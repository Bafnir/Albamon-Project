SET IDENTITY_INSERT [dbo].[TypeNFT] ON
INSERT INTO [dbo].[TypeNFT] ([Id], [Description], [Name], [Tier]) VALUES (3, N'FIRE', N'FIRE', 2)
INSERT INTO [dbo].[TypeNFT] ([Id], [Description], [Name], [Tier]) VALUES (4, N'WATER', N'WATER', 1)
INSERT INTO [dbo].[TypeNFT] ([Id], [Description], [Name], [Tier]) VALUES (5, N'LIGHT', N'LIGHT', 2)
INSERT INTO [dbo].[TypeNFT] ([Id], [Description], [Name], [Tier]) VALUES (6, N'PLANT', N'PLANT', 2)
SET IDENTITY_INSERT [dbo].[TypeNFT] OFF

SET IDENTITY_INSERT [dbo].[NFT] ON
INSERT INTO [dbo].[NFT] ([NftId], [Name], [Price], [Health], [Attack], [Rarity], [TypeNFTId]) VALUES (2, N'CHIK', 5, 10, 2, N'RARE', 3)
INSERT INTO [dbo].[NFT] ([NftId], [Name], [Price], [Health], [Attack], [Rarity], [TypeNFTId]) VALUES (4, N'CHOK', 10, 10, 2, N'NORMAL', 4)
INSERT INTO [dbo].[NFT] ([NftId], [Name], [Price], [Health], [Attack], [Rarity], [TypeNFTId]) VALUES (6, N'PAC', 7, 11, 2, N'NORMAL', 4)
INSERT INTO [dbo].[NFT] ([NftId], [Name], [Price], [Health], [Attack], [Rarity], [TypeNFTId]) VALUES (9, N'PIC', 8, 10, 1, N'RARE', 3)
SET IDENTITY_INSERT [dbo].[NFT] OFF
