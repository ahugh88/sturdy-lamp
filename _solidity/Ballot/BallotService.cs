using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using _solidity.Contracts.Ballot.ContractDefinition;

namespace _solidity.Contracts.Ballot
{
    public partial class BallotService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, BallotDeployment ballotDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<BallotDeployment>().SendRequestAndWaitForReceiptAsync(ballotDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, BallotDeployment ballotDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<BallotDeployment>().SendRequestAsync(ballotDeployment);
        }

        public static async Task<BallotService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, BallotDeployment ballotDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, ballotDeployment, cancellationTokenSource);
            return new BallotService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public BallotService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> ChairpersonQueryAsync(ChairpersonFunction chairpersonFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ChairpersonFunction, string>(chairpersonFunction, blockParameter);
        }

        
        public Task<string> ChairpersonQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ChairpersonFunction, string>(null, blockParameter);
        }

        public Task<string> DelegateRequestAsync(DelegateFunction delegateFunction)
        {
             return ContractHandler.SendRequestAsync(delegateFunction);
        }

        public Task<TransactionReceipt> DelegateRequestAndWaitForReceiptAsync(DelegateFunction delegateFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(delegateFunction, cancellationToken);
        }

        public Task<string> DelegateRequestAsync(string to)
        {
            var delegateFunction = new DelegateFunction();
                delegateFunction.To = to;
            
             return ContractHandler.SendRequestAsync(delegateFunction);
        }

        public Task<TransactionReceipt> DelegateRequestAndWaitForReceiptAsync(string to, CancellationTokenSource cancellationToken = null)
        {
            var delegateFunction = new DelegateFunction();
                delegateFunction.To = to;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(delegateFunction, cancellationToken);
        }

        public Task<string> GiveRightToVoteRequestAsync(GiveRightToVoteFunction giveRightToVoteFunction)
        {
             return ContractHandler.SendRequestAsync(giveRightToVoteFunction);
        }

        public Task<TransactionReceipt> GiveRightToVoteRequestAndWaitForReceiptAsync(GiveRightToVoteFunction giveRightToVoteFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(giveRightToVoteFunction, cancellationToken);
        }

        public Task<string> GiveRightToVoteRequestAsync(string voter)
        {
            var giveRightToVoteFunction = new GiveRightToVoteFunction();
                giveRightToVoteFunction.Voter = voter;
            
             return ContractHandler.SendRequestAsync(giveRightToVoteFunction);
        }

        public Task<TransactionReceipt> GiveRightToVoteRequestAndWaitForReceiptAsync(string voter, CancellationTokenSource cancellationToken = null)
        {
            var giveRightToVoteFunction = new GiveRightToVoteFunction();
                giveRightToVoteFunction.Voter = voter;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(giveRightToVoteFunction, cancellationToken);
        }

        public Task<ProposalsOutputDTO> ProposalsQueryAsync(ProposalsFunction proposalsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ProposalsFunction, ProposalsOutputDTO>(proposalsFunction, blockParameter);
        }

        public Task<ProposalsOutputDTO> ProposalsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var proposalsFunction = new ProposalsFunction();
                proposalsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ProposalsFunction, ProposalsOutputDTO>(proposalsFunction, blockParameter);
        }

        public Task<string> VoteRequestAsync(VoteFunction voteFunction)
        {
             return ContractHandler.SendRequestAsync(voteFunction);
        }

        public Task<TransactionReceipt> VoteRequestAndWaitForReceiptAsync(VoteFunction voteFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(voteFunction, cancellationToken);
        }

        public Task<string> VoteRequestAsync(BigInteger proposal)
        {
            var voteFunction = new VoteFunction();
                voteFunction.Proposal = proposal;
            
             return ContractHandler.SendRequestAsync(voteFunction);
        }

        public Task<TransactionReceipt> VoteRequestAndWaitForReceiptAsync(BigInteger proposal, CancellationTokenSource cancellationToken = null)
        {
            var voteFunction = new VoteFunction();
                voteFunction.Proposal = proposal;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(voteFunction, cancellationToken);
        }

        public Task<VotersOutputDTO> VotersQueryAsync(VotersFunction votersFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<VotersFunction, VotersOutputDTO>(votersFunction, blockParameter);
        }

        public Task<VotersOutputDTO> VotersQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var votersFunction = new VotersFunction();
                votersFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<VotersFunction, VotersOutputDTO>(votersFunction, blockParameter);
        }

        public Task<byte[]> WinnerNameQueryAsync(WinnerNameFunction winnerNameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WinnerNameFunction, byte[]>(winnerNameFunction, blockParameter);
        }

        
        public Task<byte[]> WinnerNameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WinnerNameFunction, byte[]>(null, blockParameter);
        }

        public Task<BigInteger> WinningProposalQueryAsync(WinningProposalFunction winningProposalFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WinningProposalFunction, BigInteger>(winningProposalFunction, blockParameter);
        }

        
        public Task<BigInteger> WinningProposalQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WinningProposalFunction, BigInteger>(null, blockParameter);
        }
    }
}
