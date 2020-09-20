
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/03/2018 09:37:57
-- Generated from EDMX file: G:\Gym\GymManagement\GymManagement\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GymDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_tblAttendance_tblMembership]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAttendance] DROP CONSTRAINT [FK_tblAttendance_tblMembership];
GO
IF OBJECT_ID(N'[dbo].[FK_tblMeasurement_tblMembership]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblMeasurement] DROP CONSTRAINT [FK_tblMeasurement_tblMembership];
GO
IF OBJECT_ID(N'[dbo].[FK_tblMembership_tblMembershipType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblMembership] DROP CONSTRAINT [FK_tblMembership_tblMembershipType];
GO
IF OBJECT_ID(N'[dbo].[FK_tblMembership_tblShift]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblMembership] DROP CONSTRAINT [FK_tblMembership_tblShift];
GO
IF OBJECT_ID(N'[dbo].[FK_tblMembership_tblUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblMembership] DROP CONSTRAINT [FK_tblMembership_tblUser];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPayment_tblMembership]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPayment] DROP CONSTRAINT [FK_tblPayment_tblMembership];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWorkout_tblMembership1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblWorkout] DROP CONSTRAINT [FK_tblWorkout_tblMembership1];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRoles_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRoles_tblUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_tblUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[tblAttendance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAttendance];
GO
IF OBJECT_ID(N'[dbo].[tblGallery]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblGallery];
GO
IF OBJECT_ID(N'[dbo].[tblMeasurement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblMeasurement];
GO
IF OBJECT_ID(N'[dbo].[tblMembership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblMembership];
GO
IF OBJECT_ID(N'[dbo].[tblMembershipType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblMembershipType];
GO
IF OBJECT_ID(N'[dbo].[tblPayment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPayment];
GO
IF OBJECT_ID(N'[dbo].[tblProtein]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProtein];
GO
IF OBJECT_ID(N'[dbo].[tblShift]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblShift];
GO
IF OBJECT_ID(N'[dbo].[tblUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblUser];
GO
IF OBJECT_ID(N'[dbo].[tblWorkout]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblWorkout];
GO
IF OBJECT_ID(N'[dbo].[UserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(50)  NULL
);
GO

-- Creating table 'tblAttendances'
CREATE TABLE [dbo].[tblAttendances] (
    [AttendanceId] int IDENTITY(1,1) NOT NULL,
    [MemberId] int  NULL,
    [Status] nvarchar(50)  NULL,
    [AttendanceDate] datetime  NULL
);
GO

-- Creating table 'tblGalleries'
CREATE TABLE [dbo].[tblGalleries] (
    [GalleryId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NULL,
    [Photo] nvarchar(50)  NULL,
    [Description] nvarchar(300)  NULL
);
GO

-- Creating table 'tblMeasurements'
CREATE TABLE [dbo].[tblMeasurements] (
    [MeasurementId] int IDENTITY(1,1) NOT NULL,
    [MemberId] int  NULL,
    [Weight] decimal(18,0)  NULL,
    [Chest] decimal(18,0)  NULL,
    [Weist] decimal(18,0)  NULL,
    [Hip] decimal(18,0)  NULL,
    [Thigh] decimal(18,0)  NULL,
    [Bicep] decimal(18,0)  NULL,
    [Forearm] decimal(18,0)  NULL,
    [MeasurementDate] datetime  NULL
);
GO

-- Creating table 'tblMemberships'
CREATE TABLE [dbo].[tblMemberships] (
    [MembershipId] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [MembershipTypeId] int  NULL,
    [RegDate] datetime  NULL,
    [Fees] decimal(18,0)  NULL,
    [ShiftId] int  NULL
);
GO

-- Creating table 'tblMembershipTypes'
CREATE TABLE [dbo].[tblMembershipTypes] (
    [MembershipTypeId] int IDENTITY(1,1) NOT NULL,
    [MembershipName] nvarchar(50)  NULL,
    [Price] decimal(18,0)  NULL,
    [AllowedMonth] int  NULL
);
GO

-- Creating table 'tblPayments'
CREATE TABLE [dbo].[tblPayments] (
    [PaymentId] int IDENTITY(1,1) NOT NULL,
    [MemberId] int  NULL,
    [PaidAmount] decimal(18,0)  NULL,
    [RemainingAmount] decimal(18,0)  NULL,
    [PaymentDate] datetime  NULL
);
GO

-- Creating table 'tblProteins'
CREATE TABLE [dbo].[tblProteins] (
    [ProteinId] int IDENTITY(1,1) NOT NULL,
    [ProteinName] nvarchar(50)  NULL,
    [Price] decimal(18,0)  NULL,
    [Description] nvarchar(50)  NULL
);
GO

-- Creating table 'tblShifts'
CREATE TABLE [dbo].[tblShifts] (
    [ShiftId] int IDENTITY(1,1) NOT NULL,
    [ShiftName] nvarchar(50)  NULL,
    [FromTime] nvarchar(50)  NULL,
    [ToTime] nvarchar(50)  NULL
);
GO

-- Creating table 'tblUsers'
CREATE TABLE [dbo].[tblUsers] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(50)  NULL,
    [Password] nvarchar(50)  NULL,
    [Usertype] nvarchar(50)  NULL,
    [Fullname] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Photo] nvarchar(50)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Gender] nvarchar(50)  NULL
);
GO

-- Creating table 'tblWorkouts'
CREATE TABLE [dbo].[tblWorkouts] (
    [WorkoutId] int IDENTITY(1,1) NOT NULL,
    [MemberId] int  NULL,
    [WorkoutDays] nvarchar(50)  NULL,
    [Description] nvarchar(50)  NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [UserRolesId] int IDENTITY(1,1) NOT NULL,
    [RoleId] int  NULL,
    [UserId] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [RoleId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [AttendanceId] in table 'tblAttendances'
ALTER TABLE [dbo].[tblAttendances]
ADD CONSTRAINT [PK_tblAttendances]
    PRIMARY KEY CLUSTERED ([AttendanceId] ASC);
GO

-- Creating primary key on [GalleryId] in table 'tblGalleries'
ALTER TABLE [dbo].[tblGalleries]
ADD CONSTRAINT [PK_tblGalleries]
    PRIMARY KEY CLUSTERED ([GalleryId] ASC);
GO

-- Creating primary key on [MeasurementId] in table 'tblMeasurements'
ALTER TABLE [dbo].[tblMeasurements]
ADD CONSTRAINT [PK_tblMeasurements]
    PRIMARY KEY CLUSTERED ([MeasurementId] ASC);
GO

-- Creating primary key on [MembershipId] in table 'tblMemberships'
ALTER TABLE [dbo].[tblMemberships]
ADD CONSTRAINT [PK_tblMemberships]
    PRIMARY KEY CLUSTERED ([MembershipId] ASC);
GO

-- Creating primary key on [MembershipTypeId] in table 'tblMembershipTypes'
ALTER TABLE [dbo].[tblMembershipTypes]
ADD CONSTRAINT [PK_tblMembershipTypes]
    PRIMARY KEY CLUSTERED ([MembershipTypeId] ASC);
GO

-- Creating primary key on [PaymentId] in table 'tblPayments'
ALTER TABLE [dbo].[tblPayments]
ADD CONSTRAINT [PK_tblPayments]
    PRIMARY KEY CLUSTERED ([PaymentId] ASC);
GO

-- Creating primary key on [ProteinId] in table 'tblProteins'
ALTER TABLE [dbo].[tblProteins]
ADD CONSTRAINT [PK_tblProteins]
    PRIMARY KEY CLUSTERED ([ProteinId] ASC);
GO

-- Creating primary key on [ShiftId] in table 'tblShifts'
ALTER TABLE [dbo].[tblShifts]
ADD CONSTRAINT [PK_tblShifts]
    PRIMARY KEY CLUSTERED ([ShiftId] ASC);
GO

-- Creating primary key on [UserId] in table 'tblUsers'
ALTER TABLE [dbo].[tblUsers]
ADD CONSTRAINT [PK_tblUsers]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [WorkoutId] in table 'tblWorkouts'
ALTER TABLE [dbo].[tblWorkouts]
ADD CONSTRAINT [PK_tblWorkouts]
    PRIMARY KEY CLUSTERED ([WorkoutId] ASC);
GO

-- Creating primary key on [UserRolesId] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([UserRolesId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RoleId] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRoles_Roles]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Roles]
        ([RoleId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRoles_Roles'
CREATE INDEX [IX_FK_UserRoles_Roles]
ON [dbo].[UserRoles]
    ([RoleId]);
GO

-- Creating foreign key on [MemberId] in table 'tblAttendances'
ALTER TABLE [dbo].[tblAttendances]
ADD CONSTRAINT [FK_tblAttendance_tblMembership]
    FOREIGN KEY ([MemberId])
    REFERENCES [dbo].[tblMemberships]
        ([MembershipId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAttendance_tblMembership'
CREATE INDEX [IX_FK_tblAttendance_tblMembership]
ON [dbo].[tblAttendances]
    ([MemberId]);
GO

-- Creating foreign key on [MemberId] in table 'tblMeasurements'
ALTER TABLE [dbo].[tblMeasurements]
ADD CONSTRAINT [FK_tblMeasurement_tblMembership]
    FOREIGN KEY ([MemberId])
    REFERENCES [dbo].[tblMemberships]
        ([MembershipId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tblMeasurement_tblMembership'
CREATE INDEX [IX_FK_tblMeasurement_tblMembership]
ON [dbo].[tblMeasurements]
    ([MemberId]);
GO

-- Creating foreign key on [MembershipTypeId] in table 'tblMemberships'
ALTER TABLE [dbo].[tblMemberships]
ADD CONSTRAINT [FK_tblMembership_tblMembershipType]
    FOREIGN KEY ([MembershipTypeId])
    REFERENCES [dbo].[tblMembershipTypes]
        ([MembershipTypeId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tblMembership_tblMembershipType'
CREATE INDEX [IX_FK_tblMembership_tblMembershipType]
ON [dbo].[tblMemberships]
    ([MembershipTypeId]);
GO

-- Creating foreign key on [ShiftId] in table 'tblMemberships'
ALTER TABLE [dbo].[tblMemberships]
ADD CONSTRAINT [FK_tblMembership_tblShift]
    FOREIGN KEY ([ShiftId])
    REFERENCES [dbo].[tblShifts]
        ([ShiftId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tblMembership_tblShift'
CREATE INDEX [IX_FK_tblMembership_tblShift]
ON [dbo].[tblMemberships]
    ([ShiftId]);
GO

-- Creating foreign key on [UserId] in table 'tblMemberships'
ALTER TABLE [dbo].[tblMemberships]
ADD CONSTRAINT [FK_tblMembership_tblUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[tblUsers]
        ([UserId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tblMembership_tblUser'
CREATE INDEX [IX_FK_tblMembership_tblUser]
ON [dbo].[tblMemberships]
    ([UserId]);
GO

-- Creating foreign key on [MemberId] in table 'tblPayments'
ALTER TABLE [dbo].[tblPayments]
ADD CONSTRAINT [FK_tblPayment_tblMembership]
    FOREIGN KEY ([MemberId])
    REFERENCES [dbo].[tblMemberships]
        ([MembershipId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPayment_tblMembership'
CREATE INDEX [IX_FK_tblPayment_tblMembership]
ON [dbo].[tblPayments]
    ([MemberId]);
GO

-- Creating foreign key on [MemberId] in table 'tblWorkouts'
ALTER TABLE [dbo].[tblWorkouts]
ADD CONSTRAINT [FK_tblWorkout_tblMembership1]
    FOREIGN KEY ([MemberId])
    REFERENCES [dbo].[tblMemberships]
        ([MembershipId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWorkout_tblMembership1'
CREATE INDEX [IX_FK_tblWorkout_tblMembership1]
ON [dbo].[tblWorkouts]
    ([MemberId]);
GO

-- Creating foreign key on [UserId] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRoles_tblUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[tblUsers]
        ([UserId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRoles_tblUser'
CREATE INDEX [IX_FK_UserRoles_tblUser]
ON [dbo].[UserRoles]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------