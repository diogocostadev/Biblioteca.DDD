# Domain-Driven Design (DDD)

## **Descrição**
O projeto utiliza o **Domain-Driven Design (DDD)**, que é uma abordagem para desenvolver sistemas complexos, colocando o foco no domínio e nas regras de negócio, garantindo que a lógica seja centralizada e separada das preocupações técnicas.

---

## **Motivos para usar o DDD**
1. **Foco no domínio**:
   - A lógica de negócios é o ponto central, facilitando a colaboração com especialistas do domínio.
2. **Separação de preocupações**:
   - Divide o sistema em camadas claras, como domínio, aplicação e infraestrutura.
3. **Evolução contínua**:
   - Facilita a manutenção e evolução de sistemas complexos.
4. **Código alinhado ao negócio**:
   - O código reflete diretamente os conceitos do domínio.

---

## **Comando Docker para Banco de Dados**
Utilizamos o SQL Server como banco de dados. Execute o seguinte comando para configurá-lo:

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Educa123!Senha" \
-p 1433:1433 --name sqlserver \
-d mcr.microsoft.com/mssql/server:2019-latest
```

Script para criar a tabela

Após configurar o banco de dados, execute o script SQL abaixo para criar a tabela Livros:

```
CREATE TABLE Livros (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Titulo NVARCHAR(255) NOT NULL,
    Autor NVARCHAR(255) NOT NULL,
    Categoria NVARCHAR(100) NOT NULL,
    Disponivel BIT NOT NULL
);

```

## Camadas do Projeto

1. Domain

	•	Entidades: Representam os dados e comportamentos principais.
	•	Exemplo: Livro.cs.
	•	Interfaces de Repositório: Contratos para acessar dados.
	•	Exemplo: ILivroRepository.cs.

2. Application

	•	Contém os casos de uso, que orquestram as interações do domínio.
	•	Exemplo: CadastrarLivroUseCase.cs.

3. Infrastructure

	•	Implementa as interfaces do domínio e conecta à infraestrutura.
	•	Exemplo: LivroRepository.cs.

4. Presentation

	•	Expõe os casos de uso via API.
	•	Exemplo: LivroController.cs.

Como rodar

	1.	Configure o banco de dados usando o comando Docker acima.
	2.	Execute o projeto no terminal:

```
dotnet run
```

	3.	Acesse os endpoints da API (e.g., via Swagger em http://localhost:5000/swagger).

---
