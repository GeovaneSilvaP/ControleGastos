import { useEffect, useState } from "react";
import { listarTransacoes } from "../../services/transacaoService";
import { Transacao } from "../../interfaces/Transacao";

/**
 * Página de listagem de transações cadastradas.
 */
export default function Transacoes() {
  const [transacoes, setTransacoes] = useState<Transacao[]>([]);

  /**
   * Busca a lista atualizada de transações na API.
   */
  async function carregar() {
    const dados = await listarTransacoes();

    setTransacoes(dados);
  }

  useEffect(() => {
    carregar();
  }, []);

  return (
    <div>
      <h2>Transações</h2>

      <table>
        <thead>
          <tr>
            <th>Descrição</th>

            <th>Valor</th>

            <th>Tipo</th>

            <th>Pessoa</th>
          </tr>
        </thead>

        <tbody>
          {transacoes.map((t) => (
            <tr key={t.id}>
              <td>{t.descricao}</td>

              <td>R$ {t.valor.toFixed(2)}</td>

              <td>{t.tipo === 2 ? "Receita" : "Despesa"}</td>

              <td>{t.pessoaId}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
