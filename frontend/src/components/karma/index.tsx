import classes from "./carmablock.module.css";

function KarmaBlock({ points, onDown, onUp }: { points: number, onDown: () => void, onUp: () => void }) {
    const accentColor: string = points > 0 ? classes.positive : points < 0 ? classes.negative : classes.neutral;
    return <div className={classes.karmaBlock}>
        <span className={[classes.arrowButton, classes.negative].join(' ')} onClick={onDown}>↓</span>
        <span className={accentColor}>{
            (points > 0 ? '+' : points < 0 ? '-' : '') + points.toString()
        }</span>
        <span className={[classes.arrowButton, classes.positive].join(' ')} onClick={onUp}>↑</span>
    </div>
}

export default KarmaBlock;