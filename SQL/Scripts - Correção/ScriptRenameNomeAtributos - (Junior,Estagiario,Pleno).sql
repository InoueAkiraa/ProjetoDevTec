-- SCRIPT PARA ALTERAR NOME DA TABLE E ATRIBUTOS EM JUNIOR
EXEC sp_rename 'junior', 'Junior'

EXEC sp_rename 'Junior.estagiario_id', 'CodigoEstagiario', 'Column';

EXEC sp_rename 'Junior.Primeiro_Nome', 'PrimeiroNome', 'Column';

EXEC sp_rename 'Junior.Sobrenome_nome', 'Sobrenome', 'Column';

EXEC sp_rename 'Junior.email', 'Email', 'Column';

EXEC sp_rename 'Junior.telefone', 'Telefone', 'Column';

EXEC sp_rename 'Junior.endereco_id', 'CodigoEndereco', 'Column';

EXEC sp_rename 'Junior.tipo_pessoa_id', 'CodigoTipoPessoa', 'Column';

EXEC sp_rename 'Junior.sigla_tipo_pessoa', 'SiglaTipoPessoa', 'Column';

EXEC sp_rename 'Junior.matricula', 'Matricula', 'Column';

EXEC sp_rename 'Junior.ativo', 'Ativo', 'Column';

EXEC sp_rename 'Junior.DataInsercao', 'DataInclusao', 'Column';

EXEC sp_rename 'Junior.data_contratacao', 'DataContratacao', 'Column';

EXEC sp_rename 'Junior.projeto_id', 'CodigoProjeto', 'Column';


-- SCRIPT PARA ALTERAR NOME DA TABLE E ATRIBUTOS EM PLENO
EXEC sp_rename 'Plenum', 'Pleno'

EXEC sp_rename 'Pleno.plenum_id', 'CodigoPlenum', 'Column';

EXEC sp_rename 'Pleno.Primeiro_Nome', 'PrimeiroNome', 'Column';

EXEC sp_rename 'Pleno.Sobrenome_nome', 'Sobrenome', 'Column';

EXEC sp_rename 'Pleno.email', 'Email', 'Column';

EXEC sp_rename 'Pleno.telefone', 'Telefone', 'Column';

EXEC sp_rename 'Pleno.endereco_id', 'CodigoEndereco', 'Column';

EXEC sp_rename 'Pleno.tipo_pessoa_id', 'CodigoTipoPessoa', 'Column';

EXEC sp_rename 'Pleno.sigla_tipo_pessoa', 'SiglaTipoPessoa', 'Column';

EXEC sp_rename 'Pleno.matricula', 'Matricula', 'Column';

EXEC sp_rename 'Pleno.ativo', 'Ativo', 'Column';

EXEC sp_rename 'Pleno.DataInsercao', 'DataInclusao', 'Column';

EXEC sp_rename 'Pleno.data_contratacao', 'DataContratacao', 'Column';

EXEC sp_rename 'Pleno.projeto_id', 'CodigoProjeto', 'Column';


-- SCRIPT PARA ALTERAR NOME DA TABLE E ATRIBUTOS EM ESTAGIARIO
EXEC sp_rename 'estagiario', 'Estagiario'

EXEC sp_rename 'Estagiario.estagiario_id', 'CodigoEstagiario', 'Column';

EXEC sp_rename 'Estagiario.Primeiro_Nome', 'PrimeiroNome', 'Column';

EXEC sp_rename 'Estagiario.Sobrenome_nome', 'Sobrenome', 'Column';

EXEC sp_rename 'Estagiario.email', 'Email', 'Column';

EXEC sp_rename 'Estagiario.telefone', 'Telefone', 'Column';

EXEC sp_rename 'Estagiario.endereco_id', 'CodigoEndereco', 'Column';

EXEC sp_rename 'Estagiario.tipo_pessoa_id', 'CodigoTipoPessoa', 'Column';

EXEC sp_rename 'Estagiario.sigla_tipo_pessoa', 'SiglaTipoPessoa', 'Column';

EXEC sp_rename 'Estagiario.matricula', 'Matricula', 'Column';

EXEC sp_rename 'Estagiario.ativo', 'Ativo', 'Column';

EXEC sp_rename 'Estagiario.DataInsercao', 'DataInclusao', 'Column';

EXEC sp_rename 'Estagiario.data_contratacao', 'DataContratacao', 'Column';

EXEC sp_rename 'Estagiario.projeto_id', 'CodigoProjeto', 'Column';