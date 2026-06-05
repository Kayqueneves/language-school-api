#  LanguageSchoolAPI

API REST para gerenciamento de uma escola de idiomas desenvolvida com ASP.NET Core, Entity Framework Core e MySQL.

## Tecnologias

* ASP.NET Core (.NET 10)
* Entity Framework Core
* MySQL
* Docker
* Swagger

## Funcionalidades

* Cadastro de alunos
* Cadastro de professores
* Cadastro de idiomas
* Cadastro de cursos
* Gerenciamento de turmas
* Matrículas de alunos
* Avaliações
* Lançamento de notas
* Controle de salas
* Controle de horários

## Estrutura do Projeto

```txt
Controllers/
DTOs/
Models/
Repository/
Services/
Data/
```

## Entidades Principais

* Student
* Teacher
* Language
* Course
* SchoolClass
* Enrollment
* Assessment
* StudentGrade
* Room
* Schedule
## Diagrama Entidade-Relacionamento (DER)

![DER](Imagens/DER.png)

## Como Executar

### Clonar o projeto

```bash
git clone https://github.com/seuusuario/LanguageSchool-api.git
```

### Restaurar dependências

```bash
dotnet restore
```

### Executar migrations

```bash
dotnet ef database update
```

### Executar aplicação

```bash
dotnet run
```

### Swagger

```txt
http://localhost:5246/swagger
```

## Regras de Negócio

* Um aluno não pode ser matriculado duas vezes na mesma turma.
* Uma turma possui limite máximo de alunos.
* Cada matrícula recebe um número único.
* Matrículas possuem status (Active, Completed, Cancelled, Suspended).
* Avaliações pertencem a uma turma.
* Notas pertencem a um aluno e a uma avaliação.

## Autor

Kayque Brito
