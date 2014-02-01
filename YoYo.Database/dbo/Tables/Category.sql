CREATE TABLE [dbo].[Category] (
    [Name]        NVARCHAR (50)  NULL,
    [Discription] NVARCHAR (256) NULL,
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [ParentID]    INT            NULL,
    [NavigateUrl] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([id] ASC)
);

