import "./SummaryCard.css";

interface Props {
  titulo: string;

  valor: number;
}

/**
 * Card de resumo usado no Dashboard para exibir
 * um valor monetário associado a um título (ex: Receitas, Despesas, Saldo).
 */
export default function SummaryCard({
  titulo,

  valor,
}: Props) {
  return (
    <div className="summary-card">
      <h3>{titulo}</h3>

      <h2>
        R$
        {valor.toFixed(2)}
      </h2>
    </div>
  );
}
