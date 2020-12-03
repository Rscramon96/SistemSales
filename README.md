# Sistemas de Vendas Online
---
## Descrição do Projeto

O projeto tem o objetivo ser um sistemas para auxiliar nas vendas online e futuramente se tornar um mini e-commerce.

#### Tecnologias Utilizadas

- Padrão MVC/MVVM
- Asp Net Core 3.1
- Entity Framework 3.1.9
- Asp Net Core Identity 2.2 
- Injection Dependecy
      - Repository
      - (Futuramente) Services
- Razor
- Bootstrap

#### 🚧 Sistemas de Vendas Online (65%) 🚧

#### Funcionalidades

- [x] Página inicial com itens mais vendidos.
- [x] Página exibindo todos o produtos.
- [x] Página exibindo os detalhes do produto selecionado.
- [x] Carrinho de compras.
- [ ] Área restrita (Cliente/ ADM).
- [x] CRUD para cadastro de produtos e categorias de produtos.
- [ ] Paginação
- [ ] Filtro de dados
- [ ] Detalhes do pedido
- [ ] Relatório de pedidos

#### Como rodar localmente

Antes de começar você precisará ter em sua máquina as seguintes ferramentas:
- [Git](https://git-scm.com)
- [VS2019](https://visualstudio.microsoft.com/pt-br/)
- [SSMS](https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

1. Na pasta escolhida, clone o repositório em sua máquina. Abra o CMD e aplique o comando abaixo:
      > $ git clone <https://github.com/Rscramon96/Sistema-de-Vendas-Online.git>
      
2. Caso queira o projeto com banco de dados vazio:

        2.1 Abra o projeto no visual studio, vá até appsettings e mude a connection string para sua máquina.
            > $ "DefaultConnection": "Data Source= LocalHost;Initial Catalog=VendasBD;Integrated Security=True"
      
        2.2  Abra o console de pacotes nugget e dê o comando para gerar o banco:
            > $ update-database

3. Caso queira o projeto com o banco de dados populado:

        3.1 Abra o arquivo, 'Vendas.sql', que se encontra na pasta do projeto,utilizando o Microsoft SQL Server Management Studio (SSMS) e execute o script para criar o banco.
  
        3.2 Abra o projeto no visual studio, vá até appsettings e mude a connection string para sua máquina.
            > ... "DefaultConnection": "Data Source= LocalHost;Initial Catalog=VendasBD;Integrated Security=True" ...  

## CONTATOS

Feito por Ramon Santos, entre em contato! <br/>
[![LinkedIn Badge](https://img.shields.io/badge/-Ramon-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/ramon-santos-25041996/)](https://www.linkedin.com/in/ramon-santos-25041996/)
[![Gmail Badge](https://img.shields.io/badge/-rscramon95@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:rscramon95@gmail.com)](mailto:rscramon95@gmail.com)
