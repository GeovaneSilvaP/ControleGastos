import { useEffect, useState } from "react";
import { obterRelatorio } from "../../services/relatorioService";
import { Relatorio } from "../../interfaces/Relatorio";
import SummaryCard from "../../components/SummaryCard/SummaryCard";

import "./Dashboard.css";

/**
 * Página inicial do sistema.
 * Exibe um resumo geral de receitas, despesas e saldo.
 */
export default function Dashboard() {
  const [dados, setDados] = useState<Relatorio>();

  useEffect(() => {
    carregar();
  }, []);

  /**
   * Busca os dados do relatório geral na API.
   */
  async function carregar() {
    const response = await obterRelatorio();

    setDados(response);
  }

  if (!dados) {
    return <h2>Carregando...</h2>;
  }

  return (
    <>
      <h1>Dashboard</h1>

      <div className="cards">
        <SummaryCard titulo="Receitas" valor={dados.totalReceitas} />

        <SummaryCard titulo="Despesas" valor={dados.totalDespesas} />

        <SummaryCard titulo="Saldo" valor={dados.saldoGeral} />
      </div>
    </>
  );
}
