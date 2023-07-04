import styled from "@emotion/styled";

export const ItemGroup = ({
  icon,
  name,
  children,
}: {
  icon: string;
  name: string;
  children: React.ReactNode;
}) => (
  <StyledItemGroup>
    <h2>
      {icon} {name}
    </h2>
    {children}
  </StyledItemGroup>
);

const StyledItemGroup = styled.div``;
