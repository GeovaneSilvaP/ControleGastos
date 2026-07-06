import { useEffect, useState } from "react";
import { obterRelatorio } from "../../services/relatorioService";
import { Relatorio } from "../../interfaces/Relatorio";
import "./Relatorio.css";

export default function RelatorioPage() {
  const [dados, setDados] = useState<Relatorio>();

  useEffect(() => {
    carregar();
  }, []);

  async function carregar() {
    setDados(await obterRelatorio());
  }

  if (!dados) {
    return <h2>Carregando...</h2>;
  }

  return (
    <div className="page-container">
      <h2>Relatório Financeiro</h2>
      <table>
        <thead>
          <tr>
            <th>Pessoa</th>
            <th>Receitas</th>
            <th>Despesas</th>
            <th>Saldo</th>
          </tr>
        </thead>
        <tbody>
          {dados.pessoas.map((p) => (
            <tr key={p.id}>
              <td>{p.nome}</td>
              <td>R$ {p.totalReceitas.toFixed(2)}</td>
              <td>R$ {p.totalDespesas.toFixed(2)}</td>
              <td>R$ {p.saldo.toFixed(2)}</td>
            </tr>
          ))}
        </tbody>
        <tfoot>
          <tr>
            <th>Total Geral</th>
            <th>R$ {dados.totalReceitas.toFixed(2)}</th>
            <th>R$ {dados.totalDespesas.toFixed(2)}</th>
            <th>R$ {dados.saldoGeral.toFixed(2)}</th>
          </tr>
        </tfoot>
      </table>
    </div>
  );
}
