SET IDENTITY_INSERT [dbo].[TypeNFT] ON
INSERT INTO [dbo].[TypeNFT] ([Id], [Description], [Name], [Tier]) VALUES (3, N'FIRE', N'FIRE', 2)
INSERT INTO [dbo].[TypeNFT] ([Id], [Description], [Name], [Tier]) VALUES (16, N'WATER', N'WATER', 1)
INSERT INTO [dbo].[TypeNFT] ([Id], [Description], [Name], [Tier]) VALUES (5, N'LIGHT', N'LIGHT', 2)
INSERT INTO [dbo].[TypeNFT] ([Id], [Description], [Name], [Tier]) VALUES (6, N'PLANT', N'PLANT', 2)
INSERT INTO [dbo].[TypeNFT] ([Id], [Description], [Name], [Tier]) VALUES (7, N'ELECTRO', N'ELECTRO', 2)
INSERT INTO [dbo].[TypeNFT] ([Id], [Description], [Name], [Tier]) VALUES (17, N'LIGHT', N'LIGHT', 1)
INSERT INTO [dbo].[TypeNFT] ([Id], [Description], [Name], [Tier]) VALUES (14, N'PLANT', N'PLANT', 2)
INSERT INTO [dbo].[TypeNFT] ([Id], [Description], [Name], [Tier]) VALUES (12, N'LIGHT', N'ELECTRO', 2)
SET IDENTITY_INSERT [dbo].[TypeNFT] OFF

SET IDENTITY_INSERT [dbo].[NFT] ON
INSERT INTO [dbo].[NFT] ([NftId], [Name], [Price], [Health], [Attack], [Rarity], [TypeNFTId]) VALUES (12, N'KOFFINGOMON', 10, 10, 2, N'RARE', 3)
INSERT INTO [dbo].[NFT] ([NftId], [Name], [Price], [Health], [Attack], [Rarity], [TypeNFTId]) VALUES (13, N'PIDGEOTOMON', 14, 10, 2, N'NORMAL', 4)
INSERT INTO [dbo].[NFT] ([NftId], [Name], [Price], [Health], [Attack], [Rarity], [TypeNFTId]) VALUES (14, N'KLINKOMON', 6, 13, 2, N'NORMAL', 4)
INSERT INTO [dbo].[NFT] ([NftId], [Name], [Price], [Health], [Attack], [Rarity], [TypeNFTId]) VALUES (15, N'ELECTRODOMON', 3, 10, 1, N'RARE', 3)
INSERT INTO [dbo].[NFT] ([NftId], [Name], [Price], [Health], [Attack], [Rarity], [TypeNFTId]) VALUES (16, N'STAYROMON', 5, 10, 1, N'RARE', 3)
INSERT INTO [dbo].[NFT] ([NftId], [Name], [Price], [Health], [Attack], [Rarity], [TypeNFTId]) VALUES (17, N'KADABRAOMON', 5, 5, 1, N'RARE', 3)
INSERT INTO [dbo].[NFT] ([NftId], [Name], [Price], [Health], [Attack], [Rarity], [TypeNFTId]) VALUES (18, N'SQUIRTLOMON', 6, 11, 1, N'RARE', 3)
SET IDENTITY_INSERT [dbo].[NFT] OFF
