CREATE TABLE [HealthStatus] (
    [Id] int NOT NULL IDENTITY,
    [Label] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_HealthStatus] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Drones] (
    [Matricule] nvarchar(25) NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    [StatusId] int NOT NULL,
    CONSTRAINT [PK_Drones] PRIMARY KEY ([Matricule]),
    CONSTRAINT [FK_Drones_HealthStatus_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [HealthStatus] ([Id])
    -- ON DELETE CASCADE
);
GO

CREATE TABLE [Login] (
    [Id] int not null IDENTITY,
    [Email] nvarchar (309) not null,
    [Password] VARBINARY not null,
    CONSTRAINT [PK_Login] PRIMARY KEY([Id])
);
GO

CREATE INDEX [IX_Drones_StatusId] ON [Drones] ([StatusId]);
GO