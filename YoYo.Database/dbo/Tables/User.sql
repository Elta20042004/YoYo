CREATE TABLE [dbo].[User] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [First Name] NVARCHAR (50) NULL,
    [Last Name]  NVARCHAR (50) NULL,
    [Email]      NVARCHAR (50) NULL,
    [Password]   NVARCHAR (50) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([ID] ASC)
);

