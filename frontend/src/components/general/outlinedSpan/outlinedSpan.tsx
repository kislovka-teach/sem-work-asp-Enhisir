import { ReactNode } from "react";
import classes from "./outlinedSpan.module.css";

function OutlinedSpan({
  classname,
  children,
  ...props
}: {
  props: any[];
  classname: string;
  children?: ReactNode;
}) {
  return (
    <span
      className={[classes.outlinedSpan, classname].join(" ").trim()}
      {...props}
    >
      {children}
    </span>
  );
}

export default OutlinedSpan;
