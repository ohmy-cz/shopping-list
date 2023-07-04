import styled from "@emotion/styled";

export function MantineDemo() {
  return <StyledComponent />;
}

const StyledComponent = styled.div`
  text-align: center;
  background-color: ${({ theme }) =>
    theme.colorScheme === "dark" ? theme.colors.dark[6] : theme.colors.gray[0]};
  padding: 1.875rem;
  border-radius: 0.3125rem;
  cursor: pointer;

  &:hover {
    background-color: ${({ theme }) =>
      theme.colorScheme === "dark"
        ? theme.colors.dark[5]
        : theme.colors.gray[1]};
  }
`;
