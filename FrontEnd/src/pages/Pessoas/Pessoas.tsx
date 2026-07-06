import { useEffect, useState } from "react";
import { Pessoa } from "../../interfaces/Pessoa";
import { listarPessoas, excluirPessoa } from "../../services/pessoaService";

import "./Pessoas.css";

/**
 * Página de listagem e exclusão de pessoas cadastradas.
 */
const Pessoas = () => {
  const [pessoas, setPessoas] = useState<Pessoa[]>([]);

  /**
   * Busca a lista atualizada de pessoas na API.
   */
  async function carregarPessoas() {
    const dados = await listarPessoas();

    setPessoas(dados);
  }

  /**
   * Exclui uma pessoa após confirmação do usuário e atualiza a lista.
   */
  async function remover(id: number) {
    const confirmar = window.confirm("Deseja realmente excluir esta pessoa?");

    if (!confirmar) return;

    await excluirPessoa(id);

    carregarPessoas();
  }

  useEffect(() => {
    carregarPessoas();
  }, []);

  return (
    <div>
      <h2>Pessoas</h2>

      <table>
        <thead>
          <tr>
            <th>ID</th>

            <th>Nome</th>

            <th>Idade</th>

            <th>Ações</th>
          </tr>
        </thead>

        <tbody>
          {pessoas.map((pessoa) => (
            <tr key={pessoa.id}>
              <td>{pessoa.id}</td>

              <td>{pessoa.nome}</td>

              <td>{pessoa.idade}</td>

              <td>
                <button onClick={() => remover(pessoa.id)}>Excluir</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Pessoas;
