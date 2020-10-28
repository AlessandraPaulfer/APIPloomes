# APIPloomes

É um programa de console elaborado na linguagem de C#, que tem como responsabilidade se comunicar com a API externa da Ploomes.
Esse programa faz as seguintes funcionalidades:

1. Cria um cliente
2. Cria uma negociação com este cliente
3. Cria uma tarefa dentro desta negociação
4. Atualiza a negociação e atribuir o valor de R$ 15.000,00
5. Finaliza a tarefa
6. Ganha a negociação
7. Escreve no histórico do cliente “Negócio fechado!”

# Endpoints consumidos da API externa

 /Contacts POST
 /Deals POST
 /Tasks POST
 /Deals PATCH
 /Tasks/Finish POST
 /Deals/Win POST
 /InteractionRecords POST
 
