import { useState } from "react";
import { useSearchParams } from "react-router-dom";

import { TagOptionContainer } from "../../../types"
import Container from "../../general/container";

function ResumeFilter() {
    const [searchParams, setSearchParams] = useSearchParams();
    const [avaliableOptions, setAvaliableOptions] = useState<TagOptionContainer[]>([]);
    const [addedOptions, setAddedOptions] = useState<TagOptionContainer[]>([]);
    const [searchString, setSearchString] = useState<string>("");

    return <Container>

    </Container>;
};

export default ResumeFilter;