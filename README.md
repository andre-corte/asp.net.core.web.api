# asp.net.core.web.api

# informações extras
- acesso ao git
	- Criar conta
	- Criar branch
	- Mapeamento
- criar solution (ASP.NET 3.1)
	- Services / Application / Business (Regra de negocio)
	- Domain (Entidades)
	- Infra - data (Acesso a dados)
	- IoC (Injeção de dependencia)
	- Utils (Classes utilitarias)
	- WebAPI (API)
	- UI - Web (Painel admin)
	
	- Cadastro de usuario
	
	
# script bando de dados
create database DbAula
go

create table Usuario (
	Id bigint identity(1,1) primary key not null,
	Nome varchar(100) not null,
	BaseEntidade varchar(200) not null,
	Senha varchar(300) not null,
	DataCadastro datetime not null,
	ResponsavelCadastro varchar(100) not null,
	Ativo bit not null
)
