CREATE TRIGGER TR_LOG_ACAO_Loja
ON dbo.TblLoja
FOR INSERT, UPDATE, DELETE
AS
	IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
		INSERT TblLogAcao (Tipo, Nome_Anteriror,Nome_Atual,Tabela,Id_HF,Data_Operacao,Erro,Maquina)
		SELECT 'UPDATE', (SELECT Nome FROM deleted), Nome,'LOJA',NULL,GETDATE(),@@ERROR,HOST_NAME() FROM inserted 
	
	ELSE IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)	 
		INSERT TblLogAcao (Tipo, Nome_Anteriror,Nome_Atual,Tabela,Id_HF,Data_Operacao,Erro,Maquina)
		SELECT 'INSERT', '', Nome,'LOJA',NULL,GETDATE(),@@ERROR,HOST_NAME() FROM inserted
	ELSE
		INSERT TblLogAcao (Tipo, Nome_Anteriror,Nome_Atual,Tabela,Id_HF,Data_Operacao,Erro,Maquina)
		SELECT 'DELETE', '', Nome,'LOJA',NULL,GETDATE(),@@ERROR,HOST_NAME() FROM deleted

		
		
		

CREATE TRIGGER TR_LOG_ACAO
ON TbLPessoa 
FOR INSERT, UPDATE, DELETE
AS
	IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
		INSERT TblLogAcao (Tipo, Nome_Anteriror,Nome_Atual,Tabela,Id_HF,Data_Operacao,Erro,Maquina)
		SELECT 'UPDATE', (SELECT Nome FROM deleted), Nome,'PESSOA',NULL,GETDATE(),@@ERROR,HOST_NAME() FROM inserted 
	
	ELSE IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)	 
		INSERT TblLogAcao (Tipo, Nome_Anteriror,Nome_Atual,Tabela,Id_HF,Data_Operacao,Erro,Maquina)
		SELECT 'INSERT', '', Nome,'PESSOA',NULL,GETDATE(),@@ERROR,HOST_NAME() FROM inserted
	ELSE
		INSERT TblLogAcao (Tipo, Nome_Anteriror,Nome_Atual,Tabela,Id_HF,Data_Operacao,Erro,Maquina)
		SELECT 'DELETE', '', Nome,'PESSOA',NULL,GETDATE(),@@ERROR,HOST_NAME() FROM deleted
	 
	 SET NOCOUNT ON   
	 
	 
	 

CREATE TRIGGER TR_VALIDAR_GERENTE
ON TblFuncionario
FOR INSERT, UPDATE
AS
	DECLARE @FUNC VARCHAR(20) = (SELECT Funcao FROM inserted)
	DECLARE @COUNT int = (SELECT COUNT(*) FROM TblFuncionario WHERE Funcao = 'GERENTE' and Id_Loja = (select Id_Loja from inserted))
	
	PRINT @FUNC
	PRINT @COUNT	
	IF(@FUNC = 'GERENTE' AND @COUNT > 1)
		ROLLBACK



CREATE TRIGGER TR_LOG_FUNCIONARIO_TblFuncionario
ON TblFuncionario
FOR INSERT, UPDATE, DELETE
AS
	IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
		INSERT TblLogFuncionario (Id_Func,FuncaoAntiga,FuncaoNova,Id_GerenteAntigo,Id_GerenteNovo,AtivoAntigo,AtivoNovo,Id_LojaAntiga,Id_LojaNova ,Maquina,Data,Tipo)
		SELECT 
			Id_Func,(select Funcao from deleted),Funcao,(select Id_Gerente from deleted),Id_Gerente,(select Ativo from deleted),Ativo,
			(select Id_Loja from deleted), Id_Loja,HOST_NAME(),GETDATE(),'UPDATE' 
		FROM inserted 	
	ELSE IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)	 
		INSERT TblLogFuncionario (Id_Func,FuncaoAntiga,FuncaoNova,Id_GerenteAntigo,Id_GerenteNovo,AtivoAntigo,AtivoNovo,Id_LojaAntiga,Id_LojaNova ,Maquina,Data,Tipo)
		SELECT 
			Id_Func,'',Funcao,'',Id_Gerente,'',Ativo,'', Id_Loja,HOST_NAME(),GETDATE(),'INSERT' 
		FROM inserted 
	ELSE
		INSERT TblLogFuncionario (Id_Func,FuncaoAntiga,FuncaoNova,Id_GerenteAntigo,Id_GerenteNovo,AtivoAntigo,AtivoNovo,Id_LojaAntiga,Id_LojaNova ,Maquina,Data,Tipo)
		SELECT 
			Id_Func,'',Funcao,'',Id_Gerente,'',Ativo,'', Id_Loja,HOST_NAME(),GETDATE(),'DELETE' 
		FROM deleted 

		
		
		
		
		
		
		
CREATE TRIGGER TR_LOG_ACAO_TblHoraFuncionario
ON dbo.TblHoraFuncionario
FOR INSERT, UPDATE, DELETE
AS
	IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
		INSERT TblLogAcao (Tipo, Nome_Anteriror,Nome_Atual,Tabela,Id_HF,Data_Operacao,Erro,Maquina,Data_HF)
		SELECT 'UPDATE', '', '','HoraFuncionario',Id_HF,GETDATE(),@@ERROR,HOST_NAME(),Data_Entrada FROM inserted 	
	ELSE IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)	 
		INSERT TblLogAcao (Tipo, Nome_Anteriror,Nome_Atual,Tabela,Id_HF,Data_Operacao,Erro,Maquina,Data_HF)
		SELECT 'INSERT', '', '','HoraFuncionario',Id_HF,GETDATE(),@@ERROR,HOST_NAME(),Data_Entrada FROM inserted
	ELSE
		INSERT TblLogAcao (Tipo, Nome_Anteriror,Nome_Atual,Tabela,Id_HF,Data_Operacao,Erro,Maquina,Data_HF)
		SELECT 'DELETE', '', '','HoraFuncionario',Id_HF,GETDATE(),@@ERROR,HOST_NAME(),Data_Entrada FROM deleted

		

CREATE TRIGGER VALIDAR_DATA
ON TblHoraFuncionario
for insert, update
as
	if exists (select 1 from inserted where Data_Entrada > GETDATE())
	begin
		rollback 
		print 'Data superiror a data atual, por favor verifique'
	end
		
	
	
