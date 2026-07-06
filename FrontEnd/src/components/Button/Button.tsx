import { ReactNode } from "react";
import "./Button.css";

interface Props {
  children: ReactNode;
  onClick?: () => void;
  type?: "button" | "submit";
  variant?: "primary" | "danger";
}

export default function Button({
  children,
  type = "button",
  variant = "primary",
  onClick,
}: Props) {
  return (
    <button type={type} onClick={onClick} className={`btn ${variant}`}>
      {children}
    </button>
  );
}