CREATE TABLE [dbo].[Addresses] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [CountryID]   INT            NOT NULL,
    [CityID]      INT            NOT NULL,
    [Ditricit]    NVARCHAR (MAX) NULL,
    [Street]      NVARCHAR (MAX) NULL,
    [Floornumber] INT            NULL,
    [DoorNumber]  INT            NULL,
    [Building]    NVARCHAR (MAX) NULL,
    [PotalCode]   NVARCHAR (MAX) NULL,
    [longitude]   NVARCHAR (MAX) NULL,
    [ultitude]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Addresses] PRIMARY KEY CLUSTERED ([ID] ASC)
);

