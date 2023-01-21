insert into DevTecDB.DBO.Senior (PrimeiroNome,SobreNome,Email,Telefone,CodigoProjeto,CodigoEndereco,CodigoTipoPessoa,SiglaTipoPessoa,Matricula,DataContratacao)
SELECT  [PrimeiroNome]
      ,[Sobrenome]
      ,[email]
      ,[telefone]
      ,[codigoprojeto]
      ,[codigoendereco]
      ,[codigotipopessoa]
      ,[siglatipopessoa]
      ,[matricula]
      ,[datacontratacao]
  FROM [DevTecDB].[dbo].[RAW_Insert_Senior]

 