ALTER TABLE fornecedores
MODIFY COLUMN Complemento VARCHAR(500) NULL DEFAULT NULL;

ALTER TABLE fornecedores
ADD COLUMN Email VARCHAR(255) NULL,
ADD COLUMN Telefone VARCHAR(255) NULL,
ADD COLUMN EnteFederativoResponsavel VARCHAR(500) NULL;

CREATE TABLE ComandoSQL(
	IdComandoSql INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	Nome VARCHAR(100),
	Descricao VARCHAR(8000),
	ComandoSQL  VARCHAR(8000),
	Grupo TINYINT,
	Ordem TINYINT
);

INSERT INTO ComandoSQL (Nome, ComandoSQL, Grupo, Ordem) VALUES ('Denúncias Enviadas', 'SELECT COUNT(*) FROM denuncias', 1, 1);
INSERT INTO ComandoSQL (Nome, ComandoSQL, Grupo, Ordem) VALUES ('Fornecedores Suspeitos', 'SELECT COUNT(DISTINCT txtCNPJCPF) FROM denuncias WHERE Situacao = ''D''', 1, 2);
INSERT INTO ComandoSQL (Nome, ComandoSQL, Grupo, Ordem) VALUES ('Parlamentares Atingidos', 'SELECT COUNT(DISTINCT txNomeParlamentar) FROM lancamentos L, denuncias D WHERE L.txtCNPJCPF = D.txtCNPJCPF AND D.Situacao = ''D''', 1, 3);
