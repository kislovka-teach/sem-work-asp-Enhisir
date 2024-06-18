import { ReactNode } from "react";
import classes from "./textarea.module.css";

export default function CustomTextArea({
  classname,
  children,
  ...props
}: {
  props: any;
  classname?: string;
  children?: ReactNode;
}) {
  return (
    <textarea
      className={[classes.customInput, classname].join(" ").trim()}
      {...props}
    >
      {children}
    </textarea>
  );
}
