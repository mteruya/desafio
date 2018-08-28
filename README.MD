# Desafio Hyperativa
Repositório do projeto desafio Hyperativa.
## API
### EndPoints: 
Login:
https://localhost:44354/api/login
Usuario : teste
senha : teste123

Consultar cartão:
https://localhost:44354/api/cartoes/<número do cartão>

Cadastrar cartão: 
https://localhost:44354/api/cartoes/novo
ex:
```json
{
    "numCartao": "44568979789789",
    "usuarioId": 1
}
```
Cadastrar por lote:
https://localhost:44354/api/cartoes/lote
ex:
```json
{
"arquivo":"REVTQUZJTy1IWVBFUkFUSVZBICAgICAgICAgICAyMDE4MDUyNExPVEUwMDAxMDAwMDEwCkMyICAgICA0NDU2ODk3OTk5OTk5OTk5CkMxICAgICA0NDU2ODk3OTIyOTY5OTk5CkMzICAgICA0NDU2ODk3OTk5OTk5OTk5CkM0ICAgICA0NDU2ODk3OTk4MTk5OTk5CkM1ICAgICA0NDU2ODk3OTk5OTk5OTk5MTI0CkM2ICAgICA0NDU2ODk3OTEyOTk5OTk5CkM3ICAgICA0NDU2ODk3OTk5OTk5OTgKQzggICAgIDQ0NTY4OTc5MTk5OTk5OTkKQzkgICAgIDQ0NTY4OTc5OTkwOTk5OTkKQzEwICAgIDQ0NTY4OTc5MTk5OTk5OTkKTE9URTAwMDEwMDAwMTAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgLy8gWzAxLTA4XUxPVEUgICBbMDktMTRdUVREIERFIFJFR0lTVFJPUwo="
}
```
