import { NavLink } from "react-router-dom";

import "./Sidebar.css";

/**
 * Barra lateral de navegação da aplicação.
 * Exibe os links para as principais páginas do sistema.
 */
export const Sidebar = () => {
  return (
    <aside className="sidebar">
      <h2>Gastos</h2>

      <nav>
        <NavLink to="/" end>Dashboard</NavLink>

        <NavLink to="/pessoas">Pessoas</NavLink>

        <NavLink to="/nova-pessoa">Nova Pessoa</NavLink>

        <NavLink to="/transacoes">Transações</NavLink>

        <NavLink to="/relatorio">Relatório</NavLink>
      </nav>
    </aside>
  );
};

export default Sidebar;
