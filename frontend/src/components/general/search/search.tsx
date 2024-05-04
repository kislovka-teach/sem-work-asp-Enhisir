import { useState } from "react";
import { useNavigate, useSearchParams } from "react-router-dom";
import CustomInput from "../input/input";

import classes from './search.module.css'

function SearchComponent({ baseSearchString }: { baseSearchString: string}) {
    const navigate = useNavigate();

    const [searchParams, ] = useSearchParams();
    const [searchString, setSearchString] = useState<string>(searchParams.get("search") ?? "");

    return <form action="post" style={{ paddingLeft: "1.5rem", paddingRight: "1.5rem", display: "flex", justifyContent: "center" }}
    onSubmit={(event) => {
        event.preventDefault();
        navigate( baseSearchString + `?search=${searchString}`);
        navigate(0); // для перезагрузки страницы
    }}>
        <CustomInput classname={classes.searchInput}
                placeholder="поиск" value={searchString}
                onChange={(e: any) => setSearchString(e.target.value)} />
    </form>
}

export default SearchComponent;