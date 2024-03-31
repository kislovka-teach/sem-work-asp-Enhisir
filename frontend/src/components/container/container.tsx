import classes from "./container.module.css"

function Container({className, children }: { className: string | undefined, children: React.ReactNode }) {
    return <div className={ [classes.container, className].join(" ") } >
        { children }
    </div>
}

export default Container;