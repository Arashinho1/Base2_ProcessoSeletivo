INTRODUÇÃO

Este documento descreve os casos de teste automatizados para o sistema de rastreamento de bugs Mantis. Os testes foram criados para verificar a funcionalidade do sistema em três áreas principais: login, criação de bugs e visualização de bugs. A seguir, apresentamos uma visão geral dos testes realizados, incluindo aspectos de usabilidade e performance.

CASOS DE TESTE

1. Teste de Login
Objetivo: Verificar se o usuário consegue fazer login no sistema Mantis com credenciais válidas.

Usabilidade: Este teste assegura que o processo de login é funcional e intuitivo para o usuário. A automação realiza as seguintes ações:

- Acessa o campo de nome de usuário e insere um nome válido.
- Clica no botão de login.
- Acessa o campo de senha e insere a senha correta.
- Clica no botão para submeter o login. 

Tempo de Execução: 

2. Teste de Criação de Bug
Objetivo: Validar a criação de um novo bug no sistema Mantis.

Usabilidade: Este teste garante que o processo de criação de um bug é claro e funcional. As ações realizadas são:

- Navega até a página de criação de bugs.
- Seleciona uma categoria de bug do menu suspenso.
- Preenche os campos de resumo e descrição do bug.
- Envia o formulário para criar o bug.

Tempo de Execução: 

3. Teste de Visualização de Bug
Objetivo: Confirmar que a visualização dos detalhes de um bug funciona corretamente.

Usabilidade: Este teste verifica se o usuário pode visualizar os detalhes de qualquer bug listado. As etapas incluem:

- Navegar até a página de visualização de bugs.
- Clicar em cada link de bug na lista para abrir os detalhes.
- Verificar se os detalhes do bug são exibidos corretamente.
- Voltar à lista de bugs para continuar a verificação.

Tempo de Execução: 

CONSIDERAÇÕES FINAIS

Este conjunto de testes garante que as principais funcionalidades do sistema Mantis estão funcionando conforme o esperado. A documentação de usabilidade ajuda a entender o comportamento do sistema e a garantir que a experiência do usuário seja satisfatória. A análise de performance permite identificar possíveis melhorias na eficiência do sistema.
