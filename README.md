#Instalação via docker
Após baixar o fonte do repositório, entrar no diretório raiz do projeto
e digitar os seguintes comandos.

docker build -t CQRS .
docker run -d -p 8080:80 CQRS

#Testes
No endpoint existem 3 parâmetros que não são obrigatórios 
para o mesmo funcionar que são: 
portal, limit, page

portal=> zap ou vivareal
limit=> número da página corrente da paginação
page=> quantidade de registros por página da paginação

Como somente existe um endpoint, favor digitar o seguinte endereço:
http://localhost:8080/api/imoveis/

Se nada for digitado, como no endereço acima, por padrão já cai no portal zap com
1 de limit e 50 de page.

http://localhost:8080/api/imoveis/?portal=vivareal&limit=1&page=40
Exemplo de parametros:
portal=vivareal
limit=1
page=40

http://localhost:8080/api/imoveis/?portal=zap&limit=1&page=25
Exemplo de parametros:
portal=zap
limit=1
page=25
