import { ReactNode } from "react";
import classes from "./input.module.css";

function CustomInput({
  classname,
  children,
  ...props
}: {
  props: any;
  classname?: string;
  children?: ReactNode;
}) {
  return (
    <input
      className={[classes.customInput, classname].join(" ").trim()}
      {...props}
    >
      {children}
    </input>
  );
}

export default CustomInput;
