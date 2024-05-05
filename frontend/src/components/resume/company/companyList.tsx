import { WorkPlace } from "../../../types";
import Container from "../../general/container";
import Company from "./company";

function CompanyList({ companies }: { companies: WorkPlace[] }) {
  if (companies.length == 0) return null;
  return (
    <Container>
      {companies.length >= 1 && <Company companyInfo={companies[0]} />}
      {companies.slice(1).flatMap((cmp) => (
        <Company companyInfo={cmp} enableUpperBorder={true} />
      ))}
    </Container>
  );
}

export default CompanyList;
