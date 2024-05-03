import { useState } from "react";
import { useNavigate, useSearchParams } from "react-router-dom";
import CustomInput from "../input/input";

function SearchComponent() {
    const navigate = useNavigate();

    const [searchParams, ] = useSearchParams();
    const [searchString, setSearchString] = useState<string>(searchParams.get("title") ?? "");

    return <form action="post" style={{ width: "100%", display: "flex", justifyContent: "center" }}
    onSubmit={(event) => {
        event.preventDefault();
        navigate(`/articles?title=${searchString}`);
        navigate(0); // для перезагрузки страницы
    }}>
        <CustomInput style={{ width: "400px", minWidth: "200px" }}
                placeholder="поиск" value={searchString}
                onChange={(e: any) => setSearchString(e.target.value)} />
    </form>
}

export default SearchComponent;