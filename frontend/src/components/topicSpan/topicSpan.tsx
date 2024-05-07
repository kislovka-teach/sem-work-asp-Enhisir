import classes from "./topicSpan.module.css";
import { Link } from "react-router-dom";
import { Topic } from "../../types";

function TopicSpan({ topic }: { topic: Topic }) {
  return (
    <span className={classes.topicSpan}>
      <Link to={`/articles?topic=${topic.id}`}>{topic.name}</Link>
    </span>
  );
}

export default TopicSpan;
