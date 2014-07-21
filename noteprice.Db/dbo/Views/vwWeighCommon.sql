CREATE VIEW [dbo].[vwWeighCommon]
AS
SELECT [Id]
      ,[Name]
      ,[Value]
      ,ISNULL([IsActive],1) as [IsActive]
      ,[SortId]
  FROM [dbo].[WeighCommon]